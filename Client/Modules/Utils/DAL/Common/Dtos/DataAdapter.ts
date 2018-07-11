import $ = require("jquery");

import queryUtils = require("./queryUtils");

class DataAdapter {

    constructor(private metadata: metadataTypes.Metadata, private baseUrl: string) { }

    /**
     * Query entity collection
     */
    queryAll(entityTypeName: string, queryObject: IQueryObject, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var self = this;
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;

        var url: string = this.baseUrl + "crud/" + entitySetName + "?" + queryUtils.renderQueryString(queryObject);

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json"
            },
            type: "GET",
            url: url,
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
            //converters: {
            //    "text json": function (data) {
            //        return $.parseJSON(data, true);
            //    }
            //}
        });
        jqxhr.then(callbackSuccess).fail(callbackError);

    }

    /**
     * Service operation call
     */
    queryServiceOperation(operationName: string, paramsQueryString: string, queryObject: IQueryObject, httpMethod: string, returnCollection: boolean, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        if (returnCollection && httpMethod === "GET") {
            queryObject.count = true;
        }
        var url: string = this.baseUrl + "operations/" + operationName + "?" + paramsQueryString + "&" + queryUtils.renderQueryString(queryObject);

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: httpMethod,
            url: url,
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);

    }

    /**
     * Retrive a single entity
     */
    loadOne(entityTypeName: string, partialEntity: any, expand: string[], callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var self = this;
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var keyNames = this.metadata.entityTypes[entityTypeName].key;
        var queryObject: IQueryObject = {
            keys: [utils.getKeyFromData(keyNames, partialEntity)],
            expand
        };
        var url = this.baseUrl + "crud/" + "single/" + entitySetName + "?" + queryUtils.renderQueryString(queryObject);

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "GET",
            url: url,
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);

    }

    /**
     * Retrive multiple entities
     */
    loadMany(entityTypeName: string, partialEntities: any[], expand: string[], callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        let entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName,
            keyNames = this.metadata.entityTypes[entityTypeName].key,
            url = this.baseUrl + "crud/" + "many/" + entitySetName + "?" + queryUtils.renderQueryString({ keys: utils.getKeyFromMultipleData(keyNames, partialEntities) });

        let jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "GET",
            url: url,
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Insert single entity
     */
    postItem(entityTypeName: string, patchItem: any, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var url = this.baseUrl + "crud/" + entitySetName;

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "POST",
            url: url,
            data: JSON.stringify(patchItem, (key, value) => key === "_entitySets" ? undefined : value),
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Insert multiple entities
     */
    postItems(entityTypeName: string, entities: any[], callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var url = this.baseUrl + "crud/" + "batch/" + entitySetName;

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "POST",
            url: url,
            data: JSON.stringify(entities, (key, value) => key === "_entitySets" ? undefined : value),
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Update single entity
     */
    putItem(entityTypeName: string, entity: any, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var keyNames = this.metadata.entityTypes[entityTypeName].key;
        var url = this.baseUrl + "crud/" + entitySetName + "?" + queryUtils.renderQueryString({ keys: [utils.getKeyFromData(keyNames, entity)] }); //utils.getUrlKeyFromData(keyNames, entity);

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "PUT",
            url: url,
            data: JSON.stringify(entity, (key, value) => key === "_entitySets" ? undefined : value),
            contentType: "application/json",
            dataType: "text json",
            //success: callBack,
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Update single entity but only the changed fields
     */
    patchItem(entityTypeName: string, item: any, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var keyNames = this.metadata.entityTypes[entityTypeName].key;
        var url = this.baseUrl + "crud/" + entitySetName + "?" + queryUtils.renderQueryString({ keys: [utils.getKeyFromData(keyNames, item.partialEntity)] }); //utils.getUrlKeyFromData(keyNames, item.partialEntity);

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "PATCH",
            url: url,
            data: JSON.stringify(item.patchItem, (key, value) => key === "_entitySets" ? undefined : value),
            contentType: "application/json",
            dataType: "text json",
            //success: callBack,
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Update multiple entities but only the changed fields
     */
    patchItems(entityTypeName: string, items: any[], callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var url = this.baseUrl + "crud/" + "batch/" + entitySetName;

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "PATCH",
            url: url,
            data: JSON.stringify(items.map((it) => it.patchItem), (key, value) => key === "_entitySets" ? undefined : value),
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Delete single entity
     */
    deleteItem(entityTypeName: string, partialEntity: any, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var keyNames = this.metadata.entityTypes[entityTypeName].key;
        var url = this.baseUrl + "crud/" + entitySetName + "?" + queryUtils.renderQueryString({ keys: [utils.getKeyFromData(keyNames, partialEntity)] }); //utils.getUrlKeyFromData(keyNames, partialEntity);

        var jqxhr = $.ajax({
            type: "DELETE",
            contentType: "application/json",
            dataType: "text json",
            url: url,
            //statusCode: {
            //    200: callBack.call(this),
            //}
        });
    }

    /**
     * Delete multiple entities
     */
    deleteItems(entityTypeName: string, items: any[], callbackSuccess: (data: any, response: any) => void, callbackError: (err: any, response: any) => void): void {
        var entitySetName = this.metadata.entityTypes[entityTypeName].entitySetName;
        var keyNames = this.metadata.entityTypes[entityTypeName].key;
        var url = this.baseUrl + "crud/" + "batch/" + entitySetName + "?" + queryUtils.renderQueryString({ keys: utils.getKeyFromMultipleData(keyNames, items) });// utils.getUrlKeyFromMultipleData(keyNames, items);;

        var jqxhr = $.ajax({
            headers: {
                Accept: "application/json",
            },
            type: "DELETE",
            url: url,
            contentType: "application/json",
            dataType: "text json",
            accepts: "application/json",
        });
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

    /**
     * Query entity collection
     */
    queryAllNext(url: string, callbackSuccess: (data: any, response: any) => void, callbackError: (err: any) => void): void {
        var jqxhr = $.getJSON(this.baseUrl.replace("api/datasource/", "") + url);
        jqxhr.then(callbackSuccess).fail(callbackError);
    }

}

export = DataAdapter;


module utils {

    export function getKeyFromData(keyNames: string[], dto: any): IDictionary<any> {
        var result: IDictionary<any> = {};
        for (let name of keyNames) {
            if (dto.hasOwnProperty(name)) {
                result[name] = dto[name];
            } else {
                throw "invalid dto";
            }
        }
        return result;
    }

    export function getKeyFromMultipleData(keyNames: string[], dtos: any[]): IDictionary<any>[] {
        var result: IDictionary<any>[] = [];
        for (let dto of dtos) {
            result.push(getKeyFromData(keyNames, dto));
        }
        return result;
    }

}