
import dataProvider = require("../../dataProvider");
import DataAdapter = require("../Dtos/DataAdapter");
import LocalViews = require("./DataViews/LocalViews");
import RemoteViews = require("./DataViews/RemoteViews");
import DataContext = require("./DataContext");
import OperationsProvider = require("./OperationsProvider");

class DataService {
    constructor(private metadata: metadataTypes.Metadata, baseUrl: string) {
        this.dataAdapter = new DataAdapter(this.metadata, baseUrl);
        this.dataContext = new DataContext(this.metadata);

        this.from = {
            local: new LocalViews(this.dataContext, this.metadata),
            remote: new RemoteViews(this.dataAdapter, this.dataContext, this.metadata),
        };

        var op = new OperationsProvider(this.dataAdapter, this.dataContext);
        this.operation = {
            function: op.initializeOperations("functions"),
            action: op.initializeOperations("actions"),
        };

    }

    from: IServiceLocation<dataProvider.ILocalViews, dataProvider.IRemoteViews>;
    operation: IServiceOperation<dataProvider.IServiceFunctions, dataProvider.IServiceActions>;

    protected dataAdapter: DataAdapter;
    protected dataContext: DataContext;

}

export = DataService;