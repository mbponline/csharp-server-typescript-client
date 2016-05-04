
import DataAdapter = require("../Dtos/DataAdapter");
import DataContext = require("../DataContext");
import DataViewRemote = require("./DataViewRemote");

class RemoteViewsBase {
    constructor(protected dataAdapter: DataAdapter, protected dataContext: DataContext) { }

    private propertyBag: IDictionary<DataViewRemote<any>> = {};

    protected getPropertyValue<T>(entityTypeName: string): DataViewRemote<T> {
        var instance: DataViewRemote<T>;
        if (this.propertyBag.hasOwnProperty(entityTypeName)) {
            instance = this.propertyBag[entityTypeName];
        } else {
            instance = new DataViewRemote<T>(entityTypeName, this.dataAdapter, this.dataContext);
            this.propertyBag[entityTypeName] = instance;
        }
        return instance;
    }

}

export = RemoteViewsBase;
