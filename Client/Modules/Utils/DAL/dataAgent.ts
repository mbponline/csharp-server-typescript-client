
import $ = require("jquery");

import dataProvider = require("Modules/Utils/DAL/dataProvider");
import DataService = require("Modules/Utils/DAL/Common/Entities/DataService");

declare var baseUrl: string;

class DataAgent {
    constructor() { }

    private _dataService: DataService;
    get dataService() {
        return this._dataService;
    }

    initialize() {
        var apiUrl = baseUrl + "api/datasource/";
        return $.getJSON(apiUrl + "crud/metadata").then((metadata: metadataTypes.Metadata) => {
            this._dataService = new DataService(metadata, apiUrl);
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


