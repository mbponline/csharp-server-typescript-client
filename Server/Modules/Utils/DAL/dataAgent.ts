
import $ = require("jquery");

import dataProvider = require("Modules/Utils/DAL/dataProvider");

class DataAgent {
    constructor() { }

    private _dataService: dataProvider.DataService;
    get dataService() {
        return this._dataService;
    }
    
    initialize() {
        var baseUrl = "/api/datasource/";
        return $.getJSON(baseUrl + "crud/metadata").then((metadata: metadataTypes.Metadata) => {
            this._dataService = new dataProvider.DataService(metadata, baseUrl);
        }).then(() => this.loadCacheData());
    }

    private loadCacheData() {

        var qryCategories = this.dataService.from.remote.Categories.getItems();
        var qryLanguages = this.dataService.from.remote.Languages.getItems();
        var qryCountriesAndCities = this.dataService.from.remote.Countries.getItems(<IQueryObject>{ expand: ["Cities"] });

        return $.when(qryCategories, qryLanguages, qryCountriesAndCities).done((r00, r01, r02) => {

        });

    }

}

var dataAgent = new DataAgent();

export = dataAgent;


