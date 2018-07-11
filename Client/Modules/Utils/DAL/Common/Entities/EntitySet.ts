
import Entity = require("./Entity");

class EntitySet<T extends IEntity> implements IEntitySet<T> {
    constructor(public entityTypeName: string, private entitySets: IDictionary<IEntitySet<any>>, private metadata: metadataTypes.Metadata) {
        this.items = [];
        this.key = this.metadata.entityTypes[this.entityTypeName].key;
        this.EntityClass = this.createEntityClass(this.metadata);
    }

    private items: T[];
    private key: string[];
    public EntityClass: any;

    navigateSingle(remoteEntity: any, remoteEntityKey: string[], navigationKey: string[]): T {
        var result = this.find((it) => this.haveSameKeysNavigation(it, navigationKey, remoteEntity, remoteEntityKey));
        return result;
    }

    navigateMulti(remoteEntity: any, remoteEntityKey: string[], navigationKey: string[]): T[] {
        var result = this.filter((it) => this.haveSameKeysNavigation(it, navigationKey, remoteEntity, remoteEntityKey));
        return result;
    }

    findByKey(partialEntity: any): T {
        var result = this.find((it) => this.haveSameKeysLocal(it, partialEntity));
        return result;
    }

    find(predicate: IPredicate<T>): T {
        for (let item of this.items) {
            if (predicate(item)) {
                return item;
            }
        }
        return null;
    }

    filter(predicate: IPredicate<T>): T[] {
        return this.items.filter(predicate);
    }

    createEntity(): T {
        var entity = new this.EntityClass();
        return entity;
    }

    deleteEntity(entity: T): void {
        var entityIndex = this.items.indexOf(entity);
        if (entityIndex !== -1) {
            entity["_entitySets"] = undefined;
            this.items.splice(entityIndex, 1);
        }
    }

    deleteAll(): void {
        for (let item of this.items) {
            item["_entitySets"] = undefined;
        }
        this.items.splice(0, this.items.length);
    }

    dispose(): void {
        this.deleteAll;
        this.entitySets = undefined;
        this.metadata = undefined;
    }

    updateEntity(dto: any): T {

        var found: any, foundIndex: number, newItem: T;

        // se cauta elementul in colectia existenta
        found = this.findByKey(dto);
        if (found === null) {
            // daca nu a fost gasit se adauga in colectie
            newItem = this.createNewItem(dto);
            this.items.push(newItem);
        } else {
            // daca a fost gasit nu se inlocuieste ci se actualizaeza datale
            // astfel ca astfel ca referintele din dataViews existente sa nu se piarda.
            newItem = this.initialize(dto, found);
        }

        return newItem;
    }

    private createNewItem(dto: any): T {
        var entity: T = this.createEntity();
        //entity["_entitySets"] = this.entitySets;
        entity._attach(this.entitySets);
        this.initialize(dto, entity);
        return entity;
    }

    private initialize(dto: any, entity: T): T {
        for (let prop in entity) {
            if (prop !== "_entitySets" && dto.hasOwnProperty(prop)) {
                if (dto[prop] && this.metadata.entityTypes[this.entityTypeName].properties[prop].type === "Date") {
                    entity[prop] = new Date(dto[prop]);
                } else {
                    entity[prop] = dto[prop];
                }
            }
        }
        return entity;
    }

    private haveSameKeysLocal(localEntity: any, remoteEntity: any): boolean {
        for (let i = 0; i < this.key.length; i++) {
            if (remoteEntity[this.key[i]] !== localEntity[this.key[i]]) {
                return false;
            }
        }
        return true;
    }

    private haveSameKeysNavigation(localEntity: any, keyLocal: string[], remoteEntity: any, keyRemote: string[]): boolean {
        for (let i = 0; i < keyLocal.length; i++) {
            if (remoteEntity[keyRemote[i]] !== localEntity[keyLocal[i]]) {
                return false;
            }
        }
        return true;
    }

    private createEntityClass(metadata: metadataTypes.Metadata): any {
        // initialize EntityClass properties
        var properties = metadata.entityTypes[this.entityTypeName].properties;
        var entityClass = class extends Entity {
            constructor() {
                super();
                var self: any = this;
                for (let prop in properties) {
                    self[prop] = properties[prop].default;
                }
            }
        };

        // initialize EntityClass navigation properties
        var entityType = metadata.entityTypes[this.entityTypeName];
        for (let navigationPropertyName in entityType.navigationProperties) {

            var metaNavElement = entityType.navigationProperties[navigationPropertyName];

            var navProp = (function (metaNavElement: metadataTypes.NavigationProperty) {
                var _entityTypeName = metaNavElement.entityTypeName;
                var _multiplicity = metaNavElement.multiplicity;
                var _keyLocal = metaNavElement.keyLocal;
                var _keyRemote = metaNavElement.keyRemote;
                var result = function () {
                    // se verifica daca EntitySet-ul este creeat in dataSet
                    // (intrucat acestea se creeaza doar daca este necesar - Lazy)
                    var remoteEntitySet: IEntitySet<any> = this._entitySets.hasOwnProperty(_entityTypeName) ? this._entitySets[_entityTypeName] : undefined;
                    if (_multiplicity === "multi") {
                        return remoteEntitySet ? remoteEntitySet.navigateMulti(this, _keyLocal, _keyRemote) : [];
                    } else {
                        return remoteEntitySet ? remoteEntitySet.navigateSingle(this, _keyLocal, _keyRemote) : null;
                    }
                };
                return result;
            })(metaNavElement);

            //// proprietati de navigare ca functii
            //metadata[entityName].prototype[navigationProperty] = navProp;

            // proprietati de navigare ca get-ers
            Object.defineProperty(entityClass.prototype, navigationPropertyName, {
                get: navProp,
                enumerable: false,
                configurable: true
            });

        }

        return entityClass;
    }

}

export = EntitySet;