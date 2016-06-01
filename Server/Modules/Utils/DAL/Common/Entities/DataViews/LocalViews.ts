
import dataProvider = require("../../../dataProvider");
import DataContext = require("../DataContext");
import DataViewLocal = require("./DataViewLocal");
import viewsUtils = require("./viewsUtils");

class LocalViews implements dataProvider.ILocalViews {
    constructor(private dataContext: DataContext, private metadata: metadataTypes.Metadata) {
        viewsUtils.initializeProperties(this, metadata);
    }

    private propertyBag: IDictionary<DataViewLocal<any>> = {};

    private getPropertyValue<T>(entityTypeName: string): DataViewLocal<T> {
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

export = LocalViews;
