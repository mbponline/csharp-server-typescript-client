
export function renderQueryObject(queryParams: IQueryParams): IQueryObject {
    var result: IQueryObject = {};

    if (queryParams.keys != null) {
        result.keys = utils.GetKeyFromString(queryParams.keys);
    }

    if (queryParams.hasOwnProperty("select")) {
        result.select = queryParams.select.split(",").map((it: string) => it.trim());
    }

    if (queryParams.hasOwnProperty("filter")) {
        result.filter = queryParams.filter;
    }

    if (queryParams.hasOwnProperty("filterExpand")) {
        result.filterExpand = queryParams.filterExpand.split(";").map((it: string) => {
            var items = it.split(":").map((it) => it.trim());
            return {
                expand: items[0],
                filter: items[1] === "*" ? "1" : items[1]
            };
        });
    }

    if (queryParams.hasOwnProperty("orderBy")) {
        result.orderBy = queryParams.orderBy.split(",").map((it: string) => it.trim());
    }

    if (queryParams.hasOwnProperty("expand")) {
        result.expand = queryParams.expand.split(",").map((it: string) => it.trim());
    }

    if (queryParams.hasOwnProperty("count")) {
        result.count = Boolean(JSON.parse(queryParams.count));
    }

    if (queryParams.hasOwnProperty("skip") && !isNaN(parseInt(queryParams.skip))) {
        result.skip = parseInt(queryParams.skip);
    }

    if (queryParams.hasOwnProperty("top") && !isNaN(parseInt(queryParams.top))) {
        result.top = parseInt(queryParams.top);
    }

    return result;
}


export function renderQueryString(queryObject: IQueryObject): string {
    var result: string[] = [];

    if (!queryObject) {
        return "";
    }

    if (queryObject.hasOwnProperty("keys") && queryObject.keys.length) {
        result.push("keys=" + utils.GetStringFromKey(queryObject.keys));
    }

    if (queryObject.hasOwnProperty("select") && queryObject.select.length) {
        result.push("select=" + queryObject.select.join(","));
    }

    if (queryObject.hasOwnProperty("filter")) {
        result.push("filter=" + queryObject.filter);
    }

    if (queryObject.hasOwnProperty("filterExpand") && queryObject.filterExpand.length) {
        result.push("filterExpand=" + queryObject.filterExpand.map((it) => it.expand + ":" + it.filter || "*").join(","));
    }

    if (queryObject.hasOwnProperty("orderBy") && queryObject.orderBy.length) {
        result.push("orderBy=" + queryObject.orderBy.join(","));
    }

    if (queryObject.hasOwnProperty("expand") && queryObject.expand.length) {
        result.push("expand=" + queryObject.expand.join(","));
    }

    if (queryObject.hasOwnProperty("count")) {
        result.push("count=" + (queryObject.count ? "true" : "false"));
    }

    if (queryObject.hasOwnProperty("skip")) {
        result.push("skip=" + queryObject.skip.toString());
    }

    if (queryObject.hasOwnProperty("top")) {
        result.push("top=" + queryObject.top.toString());
    }

    return result.join("&");
}


module utils {

    /**
     * keys=key1:1,2,3,4;key2:4,5,6,7
     * ... will become:
     * keys=[ { key1: 1, key2: 4}, { key1: 2, key2: 5 }, { key1: 2, key2: 6 }, { key1: 4, key2: 7 } ]
     */
    export function GetKeyFromString(keys: string): IDictionary<any>[] {
        var keyValueSet: IDictionary<number[]> = {};
        var count = 0;
        for (let item of keys.split(";")) {
            var keyValue = item.split(":");
            keyValueSet[keyValue[0]] = keyValue[1].split(",").map((it) => parseInt(it));
            if (!count) {
                count = keyValueSet[keyValue[0]].length;
            } else {
                if (count != keyValueSet[keyValue[0]].length) {
                    throw "parametru 'keys' incorect";
                }
            }
        }

        var result: IDictionary<any>[] = [];
        for (let i = 0; i < count; i++) {
            var resultItem: IDictionary<number> = {};
            for (let keyName in keyValueSet) {
                resultItem[keyName] = keyValueSet[keyName][i];
            }
            result.push(resultItem);
        }
        return result;
    }

    /**
     * keys=[ { key1: 1, key2: 4}, { key1: 2, key2: 5 }, { key1: 2, key2: 6 }, { key1: 4, key2: 7 } ]
     * ... will become:
     * keys=key1:1,2,3,4;key2:4,5,6,7
     */
    export function GetStringFromKey(keys: IDictionary<any>[]): string {
        var keySet: IDictionary<any[]> = {};
        for (let dto of keys) {
            for (let keyName in dto) {
                if (!keySet.hasOwnProperty(keyName)) {
                    keySet[keyName] = [];
                }
                keySet[keyName].push(dto[keyName]);
            }
        }
        var result: string[] = [];
        for (let name in keySet) {
            result.push(`${name}:${keySet[name].join(",")}`);
        }
        return result.join(";");
    }

}

