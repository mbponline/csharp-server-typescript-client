
import DataAdapter = require("../Dtos/DataAdapter");
import BusyIndicator = require("../busyIndicator");
import DataContext = require("./DataContext");

interface IParams {
    name: string;
    value: any;
    type: string;
}

class OperationsProvider {
    constructor(private dataAdapter: DataAdapter, private dataContext: DataContext) {
        this.metadata = dataContext.metadata;
    }

    private metadata: metadataTypes.Metadata;

    private getItems(operationName: string, paramsQueryString: string, queryObject: IQueryObject, returnTypeName: string): JQueryDeferred<IResult<any>> {

        var dfd = $.Deferred<IResult<any>>();

        var dataSet: any[] = [];

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error retrieving " + returnTypeName + " lists: " + error.message;
        };

        var totalCount = 0;

        var queryNext = (dto: IResultSerialResponse) => {

            if (dto && dto.data.items && dto.data.items.length) {
                totalCount = dto.data.totalCount || 0;
                var tempDataSet = this.dataContext.attachEntities(dto.data);
                dataSet = dataSet.concat(tempDataSet);
                if (dto.nextLink) {
                    this.dataAdapter.queryAllNext(dto.nextLink, queryNext, queryFailed);
                } else {
                    dfd.resolve({ rows: dataSet, totalRows: totalCount });
                    BusyIndicator.instance.stop();
                }
            } else {
                BusyIndicator.instance.start();
                this.dataAdapter.queryServiceOperation(operationName, paramsQueryString, queryObject, "GET", true, queryNext, queryFailed);
            }

        };

        queryNext(undefined);

        return dfd;
    }

    private getSingleResult(operationName: string, paramsQueryString: string, queryObject: IQueryObject, returnTypeName: string): JQueryDeferred<any> {

        var dfd = $.Deferred();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error retrieving " + returnTypeName + " single result: " + error.message;
        };

        var querySuccess = (dto: IResultSingleSerialData) => {
            var dataSet = this.dataContext.attachSingleEntitiy(dto);
            dfd.resolve(dataSet);
            BusyIndicator.instance.stop();
        };

        BusyIndicator.instance.start();
        this.dataAdapter.queryServiceOperation(operationName, paramsQueryString, queryObject, "GET", false, querySuccess, queryFailed);

        return dfd;

    }

    private postOperation(operationName: string, paramsQueryString: string, queryObject: IQueryObject): JQueryDeferred<any> {

        var dfd = $.Deferred();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error retrieving " + operationName + " value: " + error.message;
        };

        var querySuccess = (dto: any) => {
            if (dto) {
                var result = dto.hasOwnProperty("value") ? (dto.value.hasOwnProperty("results") ? dto.value.results : dto.value) : dto[operationName];
                dfd.resolve(result);
            } else {
                dfd.resolve();
            }
            BusyIndicator.instance.stop();
        };

        BusyIndicator.instance.start();
        this.dataAdapter.queryServiceOperation(operationName, paramsQueryString, queryObject, "POST", false, querySuccess, queryFailed);

        return dfd;
    }

    private getItemsPostOperation(operationName: string, paramsQueryString: string, queryObject: IQueryObject, returnTypeName: string): JQueryDeferred<IResult<any>> {

        var dfd = $.Deferred<IResult<any>>();

        var dataSet: any[] = [];

        var queryFailed = (error: any) => {
            dfd.reject(error);
        };

        var dtoList: any[];
        var querySuccess = (dto: any) => {
            var data: IResultSingleSerialData = {
                item: dto,
                entityTypeName: returnTypeName,
                relatedItems: undefined
            }
            var dataSet = this.dataContext.attachSingleEntitiy<any>(data);
            dfd.resolve(dataSet);
            BusyIndicator.instance.stop();
        };

        BusyIndicator.instance.start();
        this.dataAdapter.queryServiceOperation(operationName, paramsQueryString, queryObject, 'POST', true, querySuccess, queryFailed);

        return dfd;

    }

    private createParamsQueryString(params: IParams[]): string {
        var result = "";
        params.forEach((it) => {
            if (it.type === "boolean") {
                result += `${it.name}=${JSON.stringify(it.value)}&`;
            } else if (it.type === "Date") {
                result += `${it.name}=${JSON.stringify(it.value)}&`;
            } else {
                result += `${it.name}=${it.value}&`;
            }
        });
        result = result.substring(0, result.length - 1);
        result = result.replace(/=null/g, "=");
        return result;
    }


    initializeOperations(operationType: "functions" | "actions"): any {
        var result = {};
        var operations: metadataTypes.Operation[] = this.metadata[operationType];
        for (let it of operations) {
            var name = it.name;
            result[name] = (function (fi: OperationsProvider, sod: metadataTypes.Operation) {
                var _fi = fi;
                var _metadata = fi.metadata;
                var _operationName = sod.name;
                var _returnTypeName = sod.returnType ? sod.returnType.type : "";
                var _parameter: any[] = sod.parameters || [];
                var _httpMethod = (operationType === "functions" ? "GET" : "POST");
                var _returnCollection = sod.returnType ? sod.returnType.isCollection : false;

                var result = function () {
                    var params: IParams[] = [];
                    for (let j = 0; j < _parameter.length; j++) {
                        params.push({ name: _parameter[j].name, value: arguments[j], type: _parameter[j].type });
                    }

                    var queryObject: IQueryObject = {};
                    if (_returnCollection && operationType === "functions") {
                        queryObject = arguments[_parameter.length];
                    }

                    var paramsQueryString = _fi.createParamsQueryString(params);

                    switch (operationType) {
                        case "functions":
                            if (_returnCollection) {
                                return _fi.getItems(_operationName, paramsQueryString, queryObject, _returnTypeName);
                            } else {
                                return _fi.getSingleResult(_operationName, paramsQueryString, queryObject, _returnTypeName);
                            }
                        //break;
                        case "actions":
                            if (_returnCollection) {
                                return _fi.getItemsPostOperation(_operationName, paramsQueryString, queryObject, _returnTypeName);
                            } else {
                                return _fi.postOperation(_operationName, paramsQueryString, queryObject);
                            }
                        //break;
                        default:
                            throw "invalid http method";
                    }

                };
                return result;
            })(this, it);
        }

        return result;
    }

}

export = OperationsProvider;