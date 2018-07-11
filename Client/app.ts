import $ = require("jquery");
import ko = require("knockout");
import dataProvider = require("Modules/Utils/DAL/dataProvider");
import dataAgent = require("Modules/Utils/DAL/dataAgent");

export function start() {

    dataAgent.initialize().then(() => {
        var vm = new ApplicationViewModel();
        ko.applyBindings(vm, document.getElementById("applicationHost"));
    });

}

class ApplicationViewModel {
    constructor() {
        this.title = "Test application";
        this.currentPage = 0;
        this.items = ko.observableArray(<dataProvider.Film[]>[]);
        this.previousEnabled = ko.observable(false);
        this.nextEnabled = ko.observable(false);
        this.pageDisplay = ko.observable(this.currentPage.toString());
        this.navigate(1);
    }

    title: string;
    currentPage: number;
    pageDisplay: KnockoutObservable<string>;
    items: KnockoutObservableArray<dataProvider.Film>;

    previousEnabled: KnockoutObservable<boolean>;
    nextEnabled: KnockoutObservable<boolean>;

    previous() {
        this.navigate(-1);
    }

    next() {
        this.navigate(1);
    }

    private navigate(increment: number) {
        var pageSize = 10;
        this.currentPage += increment;

        var queryObject: IQueryObject = {
            expand: ["FilmActors.Actor", "FilmCategories.Category"],
            orderBy: ["Title ASC"],
            skip: (this.currentPage - 1) * pageSize,
            top: 10
        };

        this.previousEnabled(false);
        this.nextEnabled(false);

        // get data from rest api
        dataAgent.dataService.from.remote.Films.getItems(queryObject)
            .then((result) => {
                this.pageDisplay(`Current page ${this.currentPage} / ${result.totalRows}`);
                this.items(result.rows);
                this.previousEnabled(this.currentPage !== 1);
                this.nextEnabled(queryObject.skip < result.totalRows);
            });

    }

}
