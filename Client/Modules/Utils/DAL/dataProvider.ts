
//------------------------------------------------------------------------------
//    This code was auto-generated.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//------------------------------------------------------------------------------

module dataProvider {
    
    export interface IServiceFunctions {
        GetFilmsWithActors?: (releaseYear: number, queryObject: IQueryObject) => JQueryDeferred<IResult<Film>>;
    };

    export interface IServiceActions {
        TestAction?: (param1: number) => JQueryDeferred<void>;
    };

    export interface ILocalViews {
        Actors?: IDataViewLocal<Actor>;
        Addresses?: IDataViewLocal<Address>;
        Categories?: IDataViewLocal<Category>;
        Cities?: IDataViewLocal<City>;
        Countries?: IDataViewLocal<Country>;
        Customers?: IDataViewLocal<Customer>;
        Films?: IDataViewLocal<Film>;
        FilmActors?: IDataViewLocal<FilmActor>;
        FilmCategories?: IDataViewLocal<FilmCategory>;
        FilmTexts?: IDataViewLocal<FilmText>;
        Inventories?: IDataViewLocal<Inventory>;
        Languages?: IDataViewLocal<Language>;
        Payments?: IDataViewLocal<Payment>;
        Rentals?: IDataViewLocal<Rental>;
        Staffs?: IDataViewLocal<Staff>;
        Stores?: IDataViewLocal<Store>;
        [propName: string]: any;
    };

    export interface IRemoteViews {
        Actors?: IDataViewRemote<Actor>;
        Addresses?: IDataViewRemote<Address>;
        Categories?: IDataViewRemote<Category>;
        Cities?: IDataViewRemote<City>;
        Countries?: IDataViewRemote<Country>;
        Customers?: IDataViewRemote<Customer>;
        Films?: IDataViewRemote<Film>;
        FilmActors?: IDataViewRemote<FilmActor>;
        FilmCategories?: IDataViewRemote<FilmCategory>;
        FilmTexts?: IDataViewRemote<FilmText>;
        Inventories?: IDataViewRemote<Inventory>;
        Languages?: IDataViewRemote<Language>;
        Payments?: IDataViewRemote<Payment>;
        Rentals?: IDataViewRemote<Rental>;
        Staffs?: IDataViewRemote<Staff>;
        Stores?: IDataViewRemote<Store>;
        [propName: string]: any;
    };

    export var entityTypes = {
        Actor: "Actor",
        Address: "Address",
        Category: "Category",
        City: "City",
        Country: "Country",
        Customer: "Customer",
        Film: "Film",
        FilmActor: "FilmActor",
        FilmCategory: "FilmCategory",
        FilmText: "FilmText",
        Inventory: "Inventory",
        Language: "Language",
        Payment: "Payment",
        Rental: "Rental",
        Staff: "Staff",
        Store: "Store",
    };

    export var rules = {
        Actor: {
            ActorId: {
                required: true,
                number: true,
            },
            FirstName: {
                required: true,
                maxLength: 45,
            },
            LastName: {
                required: true,
                maxLength: 45,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Address: {
            AddressId: {
                required: true,
                number: true,
            },
            Address1: {
                required: true,
                maxLength: 50,
            },
            Address2: {
                maxLength: 50,
            },
            District: {
                required: true,
                maxLength: 20,
            },
            CityId: {
                required: true,
                number: true,
            },
            PostalCode: {
                maxLength: 10,
            },
            Phone: {
                required: true,
                maxLength: 20,
            },
            Location: {
                required: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Category: {
            CategoryId: {
                required: true,
                number: true,
            },
            Name: {
                required: true,
                maxLength: 25,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        City: {
            CityId: {
                required: true,
                number: true,
            },
            Name: {
                required: true,
                maxLength: 50,
            },
            CountryId: {
                required: true,
                number: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Country: {
            CountryId: {
                required: true,
                number: true,
            },
            Name: {
                required: true,
                maxLength: 50,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Customer: {
            CustomerId: {
                required: true,
                number: true,
            },
            StoreId: {
                required: true,
                number: true,
            },
            FirstName: {
                required: true,
                maxLength: 45,
            },
            LastName: {
                required: true,
                maxLength: 45,
            },
            Email: {
                maxLength: 50,
            },
            AddressId: {
                required: true,
                number: true,
            },
            Active: {
                required: true,
            },
            CreateDate: {
                required: true,
                date: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Film: {
            FilmId: {
                required: true,
                number: true,
            },
            Title: {
                required: true,
                maxLength: 255,
            },
            Description: {
                maxLength: 65535,
            },
            ReleaseYear: {
                number: true,
            },
            LanguageId: {
                required: true,
                number: true,
            },
            OriginalLanguageId: {
                number: true,
            },
            RentalDuration: {
                required: true,
                number: true,
            },
            RentalRate: {
                required: true,
                number: true,
            },
            Length: {
                number: true,
            },
            ReplacementCost: {
                required: true,
                number: true,
            },
            Rating: {
                maxLength: 5,
            },
            SpecialFeatures: {
                maxLength: 54,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        FilmActor: {
            ActorId: {
                required: true,
                number: true,
            },
            FilmId: {
                required: true,
                number: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        FilmCategory: {
            FilmId: {
                required: true,
                number: true,
            },
            CategoryId: {
                required: true,
                number: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        FilmText: {
            FilmId: {
                required: true,
                number: true,
            },
            Title: {
                required: true,
                maxLength: 255,
            },
            Description: {
                maxLength: 65535,
            },
        },
        Inventory: {
            InventoryId: {
                required: true,
                number: true,
            },
            FilmId: {
                required: true,
                number: true,
            },
            StoreId: {
                required: true,
                number: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Language: {
            LanguageId: {
                required: true,
                number: true,
            },
            Name: {
                required: true,
                maxLength: 20,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Payment: {
            PaymentId: {
                required: true,
                number: true,
            },
            CustomerId: {
                required: true,
                number: true,
            },
            StaffId: {
                required: true,
                number: true,
            },
            RentalId: {
                number: true,
            },
            Amount: {
                required: true,
                number: true,
            },
            PaymentDate: {
                required: true,
                date: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Rental: {
            RentalId: {
                required: true,
                number: true,
            },
            RentalDate: {
                required: true,
                date: true,
            },
            InventoryId: {
                required: true,
                number: true,
            },
            CustomerId: {
                required: true,
                number: true,
            },
            ReturnDate: {
                date: true,
            },
            StaffId: {
                required: true,
                number: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Staff: {
            StaffId: {
                required: true,
                number: true,
            },
            FirstName: {
                required: true,
                maxLength: 45,
            },
            LastName: {
                required: true,
                maxLength: 45,
            },
            AddressId: {
                required: true,
                number: true,
            },
            Picture: {
            },
            Email: {
                maxLength: 50,
            },
            StoreId: {
                required: true,
                number: true,
            },
            Active: {
                required: true,
            },
            Username: {
                required: true,
                maxLength: 16,
            },
            Password: {
                maxLength: 40,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
        Store: {
            StoreId: {
                required: true,
                number: true,
            },
            ManagerStaffId: {
                required: true,
                number: true,
            },
            AddressId: {
                required: true,
                number: true,
            },
            LastUpdate: {
                required: true,
                date: true,
            },
        },
    };

    export interface Actor {
        ActorId: number;
        FirstName: string;
        LastName: string;
        LastUpdate: Date;
        
        FilmActors: FilmActor[];
    };

    export interface Address {
        AddressId: number;
        Address1: string;
        Address2: string;
        District: string;
        CityId: number;
        PostalCode: string;
        Phone: string;
        Location: any;
        LastUpdate: Date;
        
        City: City;
        Customers: Customer[];
        Staffs: Staff[];
        Stores: Store[];
    };

    export interface Category {
        CategoryId: number;
        Name: string;
        LastUpdate: Date;
        
        FilmCategories: FilmCategory[];
    };

    export interface City {
        CityId: number;
        Name: string;
        CountryId: number;
        LastUpdate: Date;
        
        Addresses: Address[];
        Country: Country;
    };

    export interface Country {
        CountryId: number;
        Name: string;
        LastUpdate: Date;
        
        Cities: City[];
    };

    export interface Customer {
        CustomerId: number;
        StoreId: number;
        FirstName: string;
        LastName: string;
        Email: string;
        AddressId: number;
        Active: boolean;
        CreateDate: Date;
        LastUpdate: Date;
        
        Store: Store;
        Address: Address;
        Payments: Payment[];
        Rentals: Rental[];
    };

    export interface Film {
        FilmId: number;
        Title: string;
        Description: string;
        ReleaseYear: number;
        LanguageId: number;
        OriginalLanguageId: number;
        RentalDuration: number;
        RentalRate: number;
        Length: number;
        ReplacementCost: number;
        Rating: string;
        SpecialFeatures: string;
        LastUpdate: Date;
        
        Language: Language;
        Language1: Language;
        FilmActors: FilmActor[];
        FilmCategories: FilmCategory[];
        Inventories: Inventory[];
    };

    export interface FilmActor {
        ActorId: number;
        FilmId: number;
        LastUpdate: Date;
        
        Actor: Actor;
        Film: Film;
    };

    export interface FilmCategory {
        FilmId: number;
        CategoryId: number;
        LastUpdate: Date;
        
        Film: Film;
        Category: Category;
    };

    export interface FilmText {
        FilmId: number;
        Title: string;
        Description: string;
        
    };

    export interface Inventory {
        InventoryId: number;
        FilmId: number;
        StoreId: number;
        LastUpdate: Date;
        
        Film: Film;
        Store: Store;
        Rentals: Rental[];
    };

    export interface Language {
        LanguageId: number;
        Name: string;
        LastUpdate: Date;
        
        Films: Film[];
        Films1: Film[];
    };

    export interface Payment {
        PaymentId: number;
        CustomerId: number;
        StaffId: number;
        RentalId: number;
        Amount: number;
        PaymentDate: Date;
        LastUpdate: Date;
        
        Customer: Customer;
        Staff: Staff;
        Rental: Rental;
    };

    export interface Rental {
        RentalId: number;
        RentalDate: Date;
        InventoryId: number;
        CustomerId: number;
        ReturnDate: Date;
        StaffId: number;
        LastUpdate: Date;
        
        Payments: Payment[];
        Inventory: Inventory;
        Customer: Customer;
        Staff: Staff;
    };

    export interface Staff {
        StaffId: number;
        FirstName: string;
        LastName: string;
        AddressId: number;
        Picture: any;
        Email: string;
        StoreId: number;
        Active: boolean;
        Username: string;
        Password: string;
        LastUpdate: Date;
        
        Payments: Payment[];
        Rentals: Rental[];
        Address: Address;
        Store: Store;
        Stores: Store[];
    };

    export interface Store {
        StoreId: number;
        ManagerStaffId: number;
        AddressId: number;
        LastUpdate: Date;
        
        Customers: Customer[];
        Inventories: Inventory[];
        Staffs: Staff[];
        Staff: Staff;
        Address: Address;
    };

};

export = dataProvider;
