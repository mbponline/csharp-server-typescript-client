import $ = require("jquery");

declare var baseUrl: string;

module dataServiceProvider {

    export function getMetadata(callback: (metadata: metadataTypes.Metadata) => void): void {
        var url = baseUrl + 'api/datasource/crud/metadata';
        $.getJSON(url, callback);
    }

    export function getActors(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/actors';
        $.getJSON(url, callback);
    }

    export function getCustomers(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/customers';
        $.getJSON(url, callback);
    }

    export function getCustomersSelect(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/customers?select=FirstName,LastName';
        $.getJSON(url, callback);
    }

    export function getCountriesExpand(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/Countries?expand=Cities';
        $.getJSON(url, callback);
    }

    export function getFilmsOrderExpandSkipTop(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10';
        $.getJSON(url, callback);
    }

    export function getFilmsOrderExpandSkipTopFilter(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10&filter=Length>%3D80';
        $.getJSON(url, callback);
    }

    export function getFilmsOrderExpandSkipTopFilterExpand1(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + 'api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10&filterExpand=FilmActors.Actor:*';
        $.getJSON(url, callback);
    }

    export function getFilmsOrderExpandSkipTopFilterExpand2(callback: (resultSerialResponse: IResultSerialResponse) => void): void {
        var url = baseUrl + "api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10&filterExpand=FilmActors.Actor:LastName='DAVIS'";
        $.getJSON(url, callback);
    }


    export function getFilmsWithActorsOperation(callback: (resultSerialData: IResultSerialData) => void): void {
        var url = baseUrl + 'api/datasource/operations/GetFilmsWithActors?releaseYear=2006';
        $.getJSON(url, callback);
    }

}

export = dataServiceProvider;