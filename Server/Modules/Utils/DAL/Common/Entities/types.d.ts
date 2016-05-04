
interface IResult<T> {
    rows: T[];
    totalRows: number;
}

interface IPredicate<T> {
    (item: T): boolean;
}

interface ICompare<T> {
    (a: T, b: T): boolean;
}

interface IEntity {
    _attach(entitySet: IDictionary<IEntitySet<any>>): void;
    _detach(): void;
    [key: string]: any;
}

interface IEntitySet<T> {
    EntityClass: any;
    navigateSingle(remoteEntity: any, remoteEntityKey: string[], navigationKey: string[]): T;
    navigateMulti(remoteEntity: any, remoteEntityKey: string[], navigationKey: string[]): T[];
    findByKey(partialEntity: any): T;
    find(predicate: IPredicate<T>): T;
    filter(predicate: IPredicate<T>): T[];
    createEntity(): T;
    deleteEntity(entity: T): void;
    deleteAll(): void;
    dispose(): void;
    updateEntity(dto: any): T;
}

//interface IDataView<T> {
//    getItemsFromLocal(predicate: IPredicate<T>): T[];
//    getSingleItemFromLocal: {
//        (predicate: IPredicate<T>): T
//        (partialEntity: any): T
//    };
//    getItems(query?: IQueryObject): JQueryDeferred<IResult<T>>;
//    getSingleItem(partialEntity: any, expand: string[]): JQueryDeferred<T>;
//    createItemDetached(): T;
//    insertItem(entity: any): JQueryDeferred<T>;
//    insertItems(entities: any[]): JQueryDeferred<T[]>;
//    updateItem(partialEntity: any): JQueryDeferred<void>;
//    patchItem(partialEntity: any): JQueryDeferred<void>;
//    patchItems(partialEntities: any[]): JQueryDeferred<void>;
//    deleteItem(partialEntity: any): JQueryDeferred<void>;
//    deleteItems(partialEntities: any[]): JQueryDeferred<void>;
//    detachItem(entity: T): void;
//    detachItems(entities: T[]): void;
//    detachAll(): void;
//}

interface IServiceLocation<TLocal, TRemote> {
    local: TLocal;
    remote: TRemote;
}

interface IServiceOperation<TFunction, TAction> {
    function: TFunction;
    action: TAction;
}