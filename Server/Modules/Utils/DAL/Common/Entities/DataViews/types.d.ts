
interface IDataViewLocal<T> {
    getItems(predicate: IPredicate<T>): T[];
    getSingleItem(predicate: IPredicate<T>): T;
    getSingleItem(partialEntity: any): T;
    getSingleItem(partialEntity: any, expand?: string[]): IResultSingleSerialData;
    EntityClass: any;
    createItemDetached(): T;
    detachItem(entity: any): void;
    detachItems(entities: any[]): void;
    detachAll(): void;
}

interface IDataViewRemote<T> {
    getItems(query?: IQueryObject): JQueryDeferred<IResult<T>>;
    getSingleItem(partialEntity: any, expand: string[]): JQueryDeferred<T>;
    getMultipleItems(partialEntities: any[], expand: string[]): JQueryDeferred<T[]>;
    insertItem(entity: any): JQueryDeferred<T>;
    insertItems(entities: any[]): JQueryDeferred<T[]>;
    updateItem(partialEntity: any): JQueryDeferred<void>;
    patchItem(partialEntity: any): JQueryDeferred<void>;
    patchItems(partialEntities: any[]): JQueryDeferred<void>;
    deleteItem(partialEntity: any): JQueryDeferred<void>;
    deleteItems(partialEntities: any[]): JQueryDeferred<void>;
}

