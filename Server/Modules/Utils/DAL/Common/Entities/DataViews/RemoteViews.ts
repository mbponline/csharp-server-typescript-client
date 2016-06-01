
import dataProvider = require("../../../dataProvider");
import DataAdapter = require("../Dtos/DataAdapter");
import DataContext = require("../DataContext");
import DataViewRemote = require("./DataViewRemote");
import viewsUtils = require("./viewsUtils");

class RemoteViews implements dataProvider.IRemoteViews {
    constructor(private dataAdapter: DataAdapter, private dataContext: DataContext, private metadata: metadataTypes.Metadata) {
        viewsUtils.initializeProperties(this, metadata);
    }

    private propertyBag: IDictionary<DataViewRemote<any>> = {};

    private getPropertyValue<T>(entityTypeName: string): DataViewRemote<T> {
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

export = RemoteViews;
