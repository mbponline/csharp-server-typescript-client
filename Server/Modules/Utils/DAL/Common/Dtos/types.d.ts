
interface IDictionary<T> {
    [key: string]: T
}

interface IResultSerialResponse {
    nextLink: string;
    data: IResultSerialData
}

interface IResultSerialData {
    items: any[];
    entityTypeName: string;
    totalCount: number;
    relatedItems: IDictionary<any[]>;
}

interface IResultSingleSerialData {
    item: any;
    entityTypeName: string;
    relatedItems: IDictionary<any[]>;
}

interface IFilterExpand {
    expand: string;
    filter: string;
}

interface IQueryObject {
    keys?: IDictionary<any>[];
    select?: string[];
    filter?: string;
    filterExpand?: IFilterExpand[];
    orderBy?: string[];
    expand?: string[];
    count?: boolean;
    skip?: number;
    top?: number;
}

interface IQueryParams {
    keys?: string;
    select?: string;
    filter?: string;
    filterExpand?: string;
    orderBy?: string;
    expand?: string;
    count?: string;
    skip?: string;
    top?: string;
}
