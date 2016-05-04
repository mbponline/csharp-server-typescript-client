
abstract class Entity implements IEntity {
    constructor() { }
    protected _entitySets: IDictionary<IEntitySet<any>>;
    _attach(entitySets: IDictionary<IEntitySet<any>>) {
        this._entitySets = entitySets;
    };
    _detach() {
        this._entitySets = undefined;
    };
};

export = Entity;