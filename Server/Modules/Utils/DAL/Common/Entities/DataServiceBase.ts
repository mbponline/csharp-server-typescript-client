
import DataAdapter = require("../Dtos/DataAdapter");
import LocalViewsBase = require("./DataViews/LocalViewsBase");
import RemoteViewsBase = require("./DataViews/RemoteViewsBase");
import DataContext = require("./DataContext");
import OperationsProvider = require("./OperationsProvider");

abstract class DataServiceBase<TLocal extends LocalViewsBase, TRemote extends RemoteViewsBase, TFunction, TAction> {
    constructor(private metadata: metadataTypes.Metadata, baseUrl: string) {
        this.dataAdapter = new DataAdapter(this.metadata, baseUrl);
        this.dataContext = new DataContext(this.metadata);

        var op = new OperationsProvider(this.dataAdapter, this.dataContext);
        this.operation = {
            function: op.initializeOperations("functions"),
            action: op.initializeOperations("actions"),
        };
    }

    from: IServiceLocation<TLocal, TRemote>;
    operation: IServiceOperation<TFunction, TAction>;

    protected dataAdapter: DataAdapter;
    protected dataContext: DataContext;

}

export = DataServiceBase;