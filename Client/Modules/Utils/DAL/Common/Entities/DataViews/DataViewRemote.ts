
import BusyIndicator = require("../../busyIndicator");
import DataAdapter = require("../../Dtos/DataAdapter");
import DataContext = require("../DataContext");

class DataViewRemote<T> {

    private _totalCount: number = 0;

    constructor(private entityTypeName: string, private dataAdapter: DataAdapter, private dataContext: DataContext) { }

    getItems(query?: IQueryObject): JQueryDeferred<IResult<T>> {

        var dfd = $.Deferred<IResult<T>>();

        var dataSet: T[] = [];

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error retrieving " + this.entityTypeName + " lists: " + error.message;
        };

        var queryNext = (dto: IResultSerialResponse) => {

            if (dto && dto.data.items && dto.data.items.length) {
                this._totalCount = dto.data.totalCount || 0;
                var tempDataSet = this.dataContext.attachEntities<T>(dto.data);
                dataSet = dataSet.concat(tempDataSet);
                if (dto.nextLink) {
                    this.dataAdapter.queryAllNext(dto.nextLink, queryNext, queryFailed);
                } else {
                    dfd.resolve({ rows: dataSet, totalRows: this._totalCount });
                    BusyIndicator.instance.stop();
                }
            } else {
                BusyIndicator.instance.start();
                this.dataAdapter.queryAll(this.entityTypeName, query, queryNext, queryFailed);
            }

        };

        queryNext(undefined);

        return dfd;

    }

    getSingleItem(partialEntity: any, expand: string[]): JQueryDeferred<T> {

        var dfd = $.Deferred<T>();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error retriving data " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = (dto: IResultSingleSerialData) => {
            var data = this.dataContext.attachSingleEntitiy<T>(dto);
            dfd.resolve(data);
            BusyIndicator.instance.stop();
        };

        BusyIndicator.instance.start();
        this.dataAdapter.loadOne(this.entityTypeName, partialEntity, expand, querySucceeded, queryFailed);

        return dfd;
    }

    getMultipleItems(partialEntities: any[], expand: string[]): JQueryDeferred<T[]> {

        let dfd = $.Deferred<T[]>();

        let queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error retriving data " + this.entityTypeName + " item: " + error.message;
        };

        let querySucceeded = (dto: IResultSerialData) => {
            let data = this.dataContext.attachEntities<T>(dto);
            dfd.resolve(data);
            BusyIndicator.instance.stop();
        };

        BusyIndicator.instance.start();
        this.dataAdapter.loadMany(this.entityTypeName, partialEntities, expand, querySucceeded, queryFailed);

        return dfd;
    }

    insertItem(entity: any): JQueryDeferred<T> {

        var dfd = $.Deferred<T>();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error inserting " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = (dto: IResultSingleSerialData) => {
            var data = this.dataContext.attachSingleEntitiy<T>(dto);
            dfd.resolve(data);
            BusyIndicator.instance.stop();
        };

        var keyNames = this.dataContext.metadata.entityTypes[this.entityTypeName].key;
        var dataOriginal = this.dataContext.entitySets[this.entityTypeName].createEntity(); //new this._context.metadata[this.entityTypeName]();
        var patchItem = utils.getPatchItem(keyNames, entity, dataOriginal);
        BusyIndicator.instance.start();
        this.dataAdapter.postItem(this.entityTypeName, patchItem, querySucceeded, queryFailed);

        return dfd;

    }

    insertItems(entities: any[]): JQueryDeferred<T[]> {

        var dfd = $.Deferred<T[]>();

        if (entities.length === 0) {
            //throw "Introduceti cel putin o entitate in lista pentru a putea continua derularea operatiunii";
            setTimeout(() => {
                dfd.resolve([]);
            }, 10);
            return dfd;
        }

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error inserting " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = (dtos: IResultSingleSerialData[]) => {
            var data: IResultSerialData = {
                items: dtos.map((it) => it.item),
                entityTypeName: this.entityTypeName,
                totalCount: undefined,
                relatedItems: undefined,
            }
            var dataSet = this.dataContext.attachEntities<T>(data);
            dfd.resolve(dataSet);
            BusyIndicator.instance.stop();
        };

        BusyIndicator.instance.start();
        this.dataAdapter.postItems(this.entityTypeName, entities, querySucceeded, queryFailed);

        return dfd;

    }

    updateItem(partialEntity: any): JQueryDeferred<void> {

        var dfd = $.Deferred<void>();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error updating " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = () => {
            dfd.resolve();
            BusyIndicator.instance.stop();
        };

        var dataOriginal = this.dataContext.entitySets[this.entityTypeName].findByKey(partialEntity);
        // aplica modificarile datelor aflate in DataContext
        utils.applyChanges(partialEntity, dataOriginal);
        BusyIndicator.instance.start();
        this.dataAdapter.putItem(this.entityTypeName, dataOriginal, querySucceeded, queryFailed);

        return dfd;

    }

    patchItem(partialEntity: any): JQueryDeferred<void> {

        var dfd = $.Deferred<void>();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error updating " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = () => {
            dfd.resolve();
            BusyIndicator.instance.stop();
        };

        var keyNames = this.dataContext.metadata.entityTypes[this.entityTypeName].key;
        var dataOriginal = this.dataContext.entitySets[this.entityTypeName].findByKey(partialEntity);
        // creeaza un nou obiect ce va cuprinde doar campurile modificate
        var patchItem = utils.getPatchItem(keyNames, partialEntity, dataOriginal);
        var item = {
            patchItem: patchItem,
            partialEntity: partialEntity
        };
        // aplica modificarile datelor aflate in DataContext
        utils.applyChanges(partialEntity, dataOriginal);
        BusyIndicator.instance.start();
        this.dataAdapter.patchItem(this.entityTypeName, item, querySucceeded, queryFailed);

        return dfd;

    }

    patchItems(partialEntities: any[]): JQueryDeferred<void> {

        var dfd = $.Deferred<void>();

        if (partialEntities.length === 0) {
            //throw "Introduceti cel putin o entitate in lista pentru a putea continua derularea operatiunii";
            setTimeout(() => {
                dfd.resolve();
            }, 10);
            return dfd;
        }

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error updating " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = () => {
            dfd.resolve();
            BusyIndicator.instance.stop();
        };

        var keyNames = this.dataContext.metadata.entityTypes[this.entityTypeName].key;
        var dataOriginal: T, patchItem: any, items: any[] = [];
        for (let partialEntity of partialEntities) {
            dataOriginal = this.dataContext.entitySets[this.entityTypeName].findByKey(partialEntity);
            // creeaza un nou obiect ce va cuprinde doar campurile modificate
            patchItem = utils.getPatchItem(keyNames, partialEntity, dataOriginal);
            items.push({
                patchItem: patchItem,
                partialEntity: partialEntity
            });
            // aplica modificarile datelor aflate in DataContext
            utils.applyChanges(partialEntity, dataOriginal);
        }

        BusyIndicator.instance.start();
        this.dataAdapter.patchItems(this.entityTypeName, items, querySucceeded, queryFailed);

        return dfd;

    }

    deleteItem(partialEntity: any): JQueryDeferred<void> {

        var dfd = $.Deferred<void>();

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error deleting " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = () => {
            dfd.resolve();
            BusyIndicator.instance.stop();
        };


        var dataOriginal = this.dataContext.entitySets[this.entityTypeName].findByKey(partialEntity);
        this.dataContext.entitySets[this.entityTypeName].deleteEntity(dataOriginal);

        BusyIndicator.instance.start();
        this.dataAdapter.deleteItem(this.entityTypeName, partialEntity, querySucceeded, queryFailed);

        return dfd;

    }

    deleteItems(partialEntities: any[]): JQueryDeferred<void> {

        var dfd = $.Deferred<void>();

        if (partialEntities.length === 0) {
            //throw "Introduceti cel putin o entitate in lista pentru a putea continua derularea operatiunii";
            setTimeout(() => {
                dfd.resolve();
            }, 10);
            return dfd;
        }

        var queryFailed = (error: any) => {
            dfd.reject(error);
            throw "Error updating " + this.entityTypeName + " item: " + error.message;
        };

        var querySucceeded = () => {
            dfd.resolve();
            BusyIndicator.instance.stop();
        };

        var dataOriginal: any
        for (let i = 0; i < partialEntities.length; i++) {
            dataOriginal = this.dataContext.entitySets[this.entityTypeName].findByKey(partialEntities[i]);
            this.dataContext.entitySets[this.entityTypeName].deleteEntity(dataOriginal);
        }

        BusyIndicator.instance.start();
        this.dataAdapter.deleteItems(this.entityTypeName, partialEntities, querySucceeded, queryFailed);

        return dfd;

    }

}

export = DataViewRemote;

module utils {

    function haveSameType(obj1: any, obj2: any): boolean {
        var _class1 = Object.prototype.toString.call(obj1).slice(8, -1);
        var _class2 = Object.prototype.toString.call(obj2).slice(8, -1);
        return _class2 === _class1 || obj1 === undefined || obj1 === null || obj2 === undefined || obj2 === null;
    }

    export function getPatchItem(keyNames: string[], dataChanged: any, dataOriginal: any): IDictionary<any> {
        var patchItem: IDictionary<any> = {};
        var hasChanges: boolean;
        for (let prop in dataChanged) {
            hasChanges = false;
            if (dataOriginal.hasOwnProperty(prop) && dataChanged.hasOwnProperty(prop)) {
                if (haveSameType(dataOriginal[prop], dataChanged[prop])) {
                    if (dataOriginal[prop] instanceof Date && dataChanged[prop] instanceof Date) {
                        hasChanges = (dataOriginal[prop].getTime() !== dataChanged[prop].getTime());
                    } else {
                        hasChanges = (dataOriginal[prop] !== dataChanged[prop]);
                    }
                    if (hasChanges || keyNames.indexOf(prop) !== -1) {
                        patchItem[prop] = dataChanged[prop];
                    }
                } else {
                    throw "Proprietatile comparate trebuie sa aiba acelasi tip";
                }
            }
        }
        return patchItem;
    }

    export function applyChanges(source: any, destination: any): void {
        for (let prop in source) {
            if (destination.hasOwnProperty(prop) && (destination[prop] !== source[prop])) {
                destination[prop] = source[prop];
            }
        }
    }

}