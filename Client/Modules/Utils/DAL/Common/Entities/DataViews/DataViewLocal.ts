
import DataAdapter = require("../../Dtos/DataAdapter");
import DataContext = require("../DataContext");

class DataViewLocal<T> {

    private _totalCount: number = 0;

    constructor(private entityTypeName: string, private dataContext: DataContext) { }

    getItems(predicate: IPredicate<T>): T[] {
        if (this.dataContext.entitySets.hasOwnProperty(this.entityTypeName)) {
            return this.dataContext.entitySets[this.entityTypeName].filter(predicate);
        } else {
            return [];
        }
    }

    getSingleItem(predicate: IPredicate<T>): T
    getSingleItem(partialEntity: any): T

    getSingleItem(arg: any): any {
        if (this.dataContext.entitySets.hasOwnProperty(this.entityTypeName)) {
            if (arg instanceof Function) {
                return this.dataContext.entitySets[this.entityTypeName].find(arg /*predicate*/);
            } else {
                return this.dataContext.entitySets[this.entityTypeName].findByKey(arg /*partialEntity*/);
            }
        } else {
            return null;
        }
    }

    get EntityClass(): any {
        var item = this.dataContext.getEntityClass(this.entityTypeName);
        return item;
    }

    createItemDetached(): T {
        var item = this.dataContext.createItemDetached(this.entityTypeName);
        return item;
    }

    detachItem(entity: any): void {
        this.dataContext.entitySets[this.entityTypeName].deleteEntity(entity);
    }

    detachItems(entities: any[]): void {
        for (let i = 0; i < entities.length; i++) {
            this.dataContext.entitySets[this.entityTypeName].deleteEntity(entities[i]);
        }
    }

    detachAll(): void {
        this.dataContext.entitySets[this.entityTypeName].deleteAll();
    }


    refresh() {
    }

}

export = DataViewLocal;

