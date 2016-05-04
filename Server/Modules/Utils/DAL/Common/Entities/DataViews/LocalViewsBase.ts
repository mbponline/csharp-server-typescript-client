
import DataContext = require("../DataContext");
import DataViewLocal = require("./DataViewLocal");

class LocalViewsBase {
    constructor(protected dataContext: DataContext) { }

    private propertyBag: IDictionary<DataViewLocal<any>> = {};

    protected getPropertyValue<T>(entityTypeName: string): DataViewLocal<T> {
        var instance: DataViewLocal<T>;
        if (this.propertyBag.hasOwnProperty(entityTypeName)) {
            instance = this.propertyBag[entityTypeName];
        } else {
            instance = new DataViewLocal<T>(entityTypeName, this.dataContext);
            this.propertyBag[entityTypeName] = instance;
        }
        return instance;
    }

}

export = LocalViewsBase;
