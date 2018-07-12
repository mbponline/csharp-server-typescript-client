import dataServiceProvider = require("./dataServiceProvider");

describe('api/datasource/crud/metadata', function () {

    var metadata: metadataTypes.Metadata;
    beforeAll(function (done) {
        dataServiceProvider.getMetadata((result) => {
            metadata = result;
            done();
        });
    });

    it("should have property 'namespace'", function () {
        expect(metadata.hasOwnProperty('namespace')).toBe(true);
    });

    it("should have property 'entityTypes'", function () {
        expect(metadata.hasOwnProperty('entityTypes')).toBe(true);
    });

});

describe('api/datasource/crud/actors', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getActors((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("should have a specific value for 'nextLink'", function () {
        expect(resultSerialResponse.nextLink).toBe('api/datasource/crud/Actors?skip=40&top=200');
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 40", function () {
        expect(resultSerialResponse.data.items.length).toBe(40);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Actor'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Actor');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the value for 'relatedItems' should be null", function () {
        expect(resultSerialResponse.data.relatedItems).toBe(null);
    });

});

describe('api/datasource/crud/customers', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getCustomers((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("should have a specific value for 'nextLink'", function () {
        expect(resultSerialResponse.nextLink).toBe('api/datasource/crud/Customers?skip=40&top=599');
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 40", function () {
        expect(resultSerialResponse.data.items.length).toBe(40);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Customer'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Customer');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the value for 'relatedItems' should be null", function () {
        expect(resultSerialResponse.data.relatedItems).toBe(null);
    });

});

describe('api/datasource/crud/customers?select=FirstName,LastName', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getCustomersSelect((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("should have a specific value for 'nextLink'", function () {
        expect(resultSerialResponse.nextLink).toBe('api/datasource/crud/Customers?select=FirstName,LastName&skip=40&top=599');
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 40", function () {
        expect(resultSerialResponse.data.items.length).toBe(40);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Customer'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Customer');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the value for 'relatedItems' should be null", function () {
        expect(resultSerialResponse.data.relatedItems).toBe(null);
    });

    it("should have property 'CustomerId' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('CustomerId')).toBe(true);
    });

    it("should have property 'FirstName' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('FirstName')).toBe(true);
    });

    it("should have property 'LastName' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('LastName')).toBe(true);
    });

    it("should NOT have property 'StoreId' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('StoreId')).toBe(false);
    });

    it("should NOT have property 'Email' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('Email')).toBe(false);
    });

    it("should NOT have property 'AddressId' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('AddressId')).toBe(false);
    });

    it("should NOT have property 'Active' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('Active')).toBe(false);
    });

    it("should NOT have property 'CreateDate' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('CreateDate')).toBe(false);
    });

    it("should NOT have property 'LastUpdate' on 'data.items[0]'", function () {
        expect(resultSerialResponse.data.items[0].hasOwnProperty('LastUpdate')).toBe(false);
    });


});

describe('api/datasource/crud/Countries?expand=Cities', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getCountriesExpand((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("should have a specific value for 'nextLink'", function () {
        expect(resultSerialResponse.nextLink).toBe('api/datasource/crud/Countries?expand=Cities&skip=40&top=109');
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 40", function () {
        expect(resultSerialResponse.data.items.length).toBe(40);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Country'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Country');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the field 'relatedItems' of 'data' should have property 'City'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('City')).toBe(true);
    });

    it("the field 'City' of 'relatedItems' should be an array having length of 220", function () {
        expect(resultSerialResponse.data.relatedItems['City'].length).toBe(220);
    });

});

describe('api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getFilmsOrderExpandSkipTop((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("the value for 'nextLink' should be null", function () {
        expect(resultSerialResponse.nextLink).toBe(null);
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.items.length).toBe(10);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Film'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Film');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmActor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmActor')).toBe(true);
    });

    it("the field 'FilmActor' of 'relatedItems' should be an array having length of 52", function () {
        expect(resultSerialResponse.data.relatedItems['FilmActor'].length).toBe(52);
    });

    it("the field 'relatedItems' of 'data' should have property 'Actor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Actor')).toBe(true);
    });

    it("the field 'Actor' of 'relatedItems' should be an array having length of 45", function () {
        expect(resultSerialResponse.data.relatedItems['Actor'].length).toBe(45);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmCategory'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmCategory')).toBe(true);
    });

    it("the field 'FilmCategory' of 'relatedItems' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.relatedItems['FilmCategory'].length).toBe(10);
    });

    it("the field 'relatedItems' of 'data' should have property 'Category'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Category')).toBe(true);
    });

    it("the field 'Category' of 'relatedItems' should be an array having length of 7", function () {
        expect(resultSerialResponse.data.relatedItems['Category'].length).toBe(7);
    });

});

describe('api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10&filter=Length>=80', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getFilmsOrderExpandSkipTopFilter((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("the value for 'nextLink' should be null", function () {
        expect(resultSerialResponse.nextLink).toBe(null);
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.items.length).toBe(10);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Film'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Film');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmActor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmActor')).toBe(true);
    });

    it("the field 'FilmActor' of 'relatedItems' should be an array having length of 54", function () {
        expect(resultSerialResponse.data.relatedItems['FilmActor'].length).toBe(54);
    });

    it("the field 'relatedItems' of 'data' should have property 'Actor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Actor')).toBe(true);
    });

    it("the field 'Actor' of 'relatedItems' should be an array having length of 44", function () {
        expect(resultSerialResponse.data.relatedItems['Actor'].length).toBe(44);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmCategory'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmCategory')).toBe(true);
    });

    it("the field 'FilmCategory' of 'relatedItems' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.relatedItems['FilmCategory'].length).toBe(10);
    });

    it("the field 'relatedItems' of 'data' should have property 'Category'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Category')).toBe(true);
    });

    it("the field 'Category' of 'relatedItems' should be an array having length of 9", function () {
        expect(resultSerialResponse.data.relatedItems['Category'].length).toBe(9);
    });

    it("all objects on 'data.items'should have the value of property 'Length' >= 80", function () {
        var result = true;
        for (var item of resultSerialResponse.data.items) {
            if (!(item['Length'] >= 80)) {
                result = false;
                break;
            }
        }
        expect(result).toBe(true);
    });

});

describe('api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10&filterExpand=FilmActors.Actor:*', function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getFilmsOrderExpandSkipTopFilterExpand1((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("the value for 'nextLink' should be null", function () {
        expect(resultSerialResponse.nextLink).toBe(null);
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.items.length).toBe(10);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Film'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Film');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmActor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmActor')).toBe(true);
    });

    it("the field 'FilmActor' of 'relatedItems' should be an array having length of 52", function () {
        expect(resultSerialResponse.data.relatedItems['FilmActor'].length).toBe(52);
    });

    it("the field 'relatedItems' of 'data' should have property 'Actor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Actor')).toBe(true);
    });

    it("the field 'Actor' of 'relatedItems' should be an array having length of 17", function () {
        expect(resultSerialResponse.data.relatedItems['Actor'].length).toBe(17);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmCategory'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmCategory')).toBe(true);
    });

    it("the field 'FilmCategory' of 'relatedItems' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.relatedItems['FilmCategory'].length).toBe(10);
    });

    it("the field 'relatedItems' of 'data' should have property 'Category'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Category')).toBe(true);
    });

    it("the field 'Category' of 'relatedItems' should be an array having length of 3", function () {
        expect(resultSerialResponse.data.relatedItems['Category'].length).toBe(3);
    });

});

describe("api/datasource/crud/Films?orderBy=Title ASC&expand=FilmActors.Actor,FilmCategories.Category&skip=20&top=10&filterExpand=FilmActors.Actor:LastName='DAVIS'", function () {

    var resultSerialResponse: IResultSerialResponse;
    beforeAll(function (done) {
        dataServiceProvider.getFilmsOrderExpandSkipTopFilterExpand2((result) => {
            resultSerialResponse = result;
            done();
        });
    });

    it("should have property 'nextLink'", function () {
        expect(resultSerialResponse.hasOwnProperty('nextLink')).toBe(true);
    });

    it("the value for 'nextLink' should be null", function () {
        expect(resultSerialResponse.nextLink).toBe(null);
    });

    it("should have property 'data'", function () {
        expect(resultSerialResponse.hasOwnProperty('data')).toBe(true);
    });

    it("should have property 'items' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.items.length).toBe(10);
    });

    it("should have property 'entityTypeName' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Film'", function () {
        expect(resultSerialResponse.data.entityTypeName).toBe('Film');
    });

    it("should have property 'relatedItems' on 'data'", function () {
        expect(resultSerialResponse.data.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmActor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmActor')).toBe(true);
    });

    it("the field 'FilmActor' of 'relatedItems' should be an array having length of 57", function () {
        expect(resultSerialResponse.data.relatedItems['FilmActor'].length).toBe(57);
    });

    it("the field 'relatedItems' of 'data' should have property 'Actor'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Actor')).toBe(true);
    });

    it("the field 'Actor' of 'relatedItems' should be an array having length of 45", function () {
        expect(resultSerialResponse.data.relatedItems['Actor'].length).toBe(45);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmCategory'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('FilmCategory')).toBe(true);
    });

    it("the field 'FilmCategory' of 'relatedItems' should be an array having length of 10", function () {
        expect(resultSerialResponse.data.relatedItems['FilmCategory'].length).toBe(10);
    });

    it("the field 'relatedItems' of 'data' should have property 'Category'", function () {
        expect(resultSerialResponse.data.relatedItems.hasOwnProperty('Category')).toBe(true);
    });

    it("the field 'Category' of 'relatedItems' should be an array having length of 9", function () {
        expect(resultSerialResponse.data.relatedItems['Category'].length).toBe(9);
    });

});

describe('api/datasource/operations/GetFilmsWithActors?releaseYear=2006', function () {

    var resultSerialData: IResultSerialData;
    beforeAll(function (done) {
        dataServiceProvider.getFilmsWithActorsOperation((result) => {
            resultSerialData = result;
            done();
        });
    });

    it("should have property 'items'", function () {
        expect(resultSerialData.hasOwnProperty('items')).toBe(true);
    });

    it("'items' should be an array having length of 1000", function () {
        expect(resultSerialData.items.length).toBe(1000);
    });

    it("should have property 'entityTypeName'", function () {
        expect(resultSerialData.hasOwnProperty('entityTypeName')).toBe(true);
    });

    it("the value for 'entityTypeName' field should be 'Film'", function () {
        expect(resultSerialData.entityTypeName).toBe('Film');
    });

    it("should have property 'relatedItems'", function () {
        expect(resultSerialData.hasOwnProperty('relatedItems')).toBe(true);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmActor'", function () {
        expect(resultSerialData.relatedItems.hasOwnProperty('FilmActor')).toBe(true);
    });

    it("the field 'FilmActor' of 'relatedItems' should be an array having length of 5462", function () {
        expect(resultSerialData.relatedItems['FilmActor'].length).toBe(5462);
    });

    it("the field 'relatedItems' of 'data' should have property 'Actor'", function () {
        expect(resultSerialData.relatedItems.hasOwnProperty('Actor')).toBe(true);
    });

    it("the field 'Actor' of 'relatedItems' should be an array having length of 200", function () {
        expect(resultSerialData.relatedItems['Actor'].length).toBe(200);
    });

    it("the field 'relatedItems' of 'data' should have property 'FilmCategory'", function () {
        expect(resultSerialData.relatedItems.hasOwnProperty('FilmCategory')).toBe(true);
    });

    it("the field 'FilmCategory' of 'relatedItems' should be an array having length of 1000", function () {
        expect(resultSerialData.relatedItems['FilmCategory'].length).toBe(1000);
    });

});
