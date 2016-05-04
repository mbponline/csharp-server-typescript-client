
import EntitySet = require("./EntitySet");

class DataContext {

    constructor(public metadata: metadataTypes.Metadata) { }

    entitySets: IDictionary<IEntitySet<any>> = {};

    getEntityClass(entityTypeName: string): any {
        if (!this.entitySets.hasOwnProperty(entityTypeName)) {
            this.initializeDataSet(entityTypeName);
        }
        return this.entitySets[entityTypeName].EntityClass;
    }

    createItemDetached(entityTypeName: string): any {
        if (!this.entitySets.hasOwnProperty(entityTypeName)) {
            this.initializeDataSet(entityTypeName);
        }
        var item = this.entitySets[entityTypeName].createEntity();
        return item;
    }

    clear(): void {
        for (let prop in this.entitySets) {
            this.entitySets[prop].deleteAll();
        }
    }

    dispose(): void {
        // se va apela inainte de incetarea utilizarii obiectului
        // pentru a evita aparitia de memory leaks si a usura activitatea GC-ului
        for (let prop in this.entitySets) {
            this.entitySets[prop].dispose();
        }
        this.entitySets = undefined;
        this.metadata = undefined;
    }

    attachEntities<T>(entities: IResultSerialData): T[] {
        var entityTypeName = entities.entityTypeName;
        var dataSet = this.traverseResults<T>(entityTypeName, entities.items);
        this.attachRelatedItems(entities.relatedItems);
        return dataSet;
    }

    attachSingleEntitiy<T>(entities: IResultSingleSerialData): T {
        var entityTypeName = entities.entityTypeName;
        var dataSet = this.traverseResults<T>(entityTypeName, [entities.item]);
        this.attachRelatedItems(entities.relatedItems);
        return dataSet[0];
    }

    private attachRelatedItems(relatedItems: IDictionary<any[]>): void {
        var entityTypeName = "";
        for (let entityTypeName in relatedItems) {
            this.traverseResults<any>(entityTypeName, relatedItems[entityTypeName]);
        }
    }

    private traverseResults<T>(entityTypeName: string, results: any[]): T[] {
        if (!this.entitySets.hasOwnProperty(entityTypeName)) {
            this.initializeDataSet(entityTypeName);
        }
        var entities = this.processEntitySet<T>(entityTypeName, results);
        return entities;
    }

    private processEntitySet<T>(entityTypeName: string, results: any[]): T[] {
        var entities: T[] = [],
            item: any,
            newEntity: T;

        for (let item of results) {
            newEntity = this.processEntity<T>(entityTypeName, item);
            entities.push(newEntity);
        }
        return entities;
    }

    private processEntity<T>(entityTypeName: string, item: any): T {
        //if (!this.entitySets.hasOwnProperty(entityTypeName)) {
        //    this.initializeDataSet(entityTypeName);
        //}
        var newItem = this.entitySets[entityTypeName].updateEntity(item);
        return newItem;
    }

    private initializeDataSet(entityTypeName: string): void {
        // Initializeaza EntitySet-ul precizat la momentul utilizarii (Lazy)
        this.entitySets[entityTypeName] = new EntitySet(entityTypeName, this.entitySets, this.metadata);
    }

}

export = DataContext;



