#pragma warning disable SA1649, SA1128, SA1005, SA1516, SA1402, SA1028, SA1119, SA1507, SA1502, SA1508, SA1122, SA1633, SA1300

//------------------------------------------------------------------------------
//    This code was auto-generated.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//------------------------------------------------------------------------------

using NavyBlueDtos;
using NavyBlueEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Hosting;
using MetadataSrv = NavyBlueDtos.MetadataSrv;

namespace Server.Models.DataAccess
{
    public class DataService : DataServiceEntity<LocalEntityViews, LocalDtoViews, RemoteEntityViews, RemoteDtoViews>
    {
        public DataService(string pathMetadata, string connectionString) : base(pathMetadata, connectionString)
        {
            this.From = new ServiceLocation<LocalEntityViews, LocalDtoViews, RemoteEntityViews, RemoteDtoViews>()
            {
                Local = new ViewType<LocalEntityViews, LocalDtoViews>() { EntityView = new LocalEntityViews(this.DataContext), DtoView = new LocalDtoViews(this.DataContext, this.MetadataSrv) },
                Remote = new ViewType<RemoteEntityViews, RemoteDtoViews>() { EntityView = new RemoteEntityViews(this.DataViewDto, this.DataContext), DtoView = new RemoteDtoViews(this.DataViewDto) }
            };
        }

        public static DataService CreateDataServiceInstance()
        {
            var pathMetadata = HostingEnvironment.MapPath(@"~/App_Data");
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dataService = new DataService(pathMetadata, connectionString);
            return dataService;
        }
    }

    public class LocalEntityViews : LocalEntityViewsBase
    {
        public LocalEntityViews(DataContext dataContext) : base(dataContext)
        {
            //this.["Actors"] = new DataViewLocalEntity(dataContext);
            //this.["Addresses"] = new DataViewLocalEntity(dataContext);
            //this.["Categories"] = new DataViewLocalEntity(dataContext);
            //this.["Cities"] = new DataViewLocalEntity(dataContext);
            //this.["Countries"] = new DataViewLocalEntity(dataContext);
            //this.["Customers"] = new DataViewLocalEntity(dataContext);
            //this.["Films"] = new DataViewLocalEntity(dataContext);
            //this.["FilmActors"] = new DataViewLocalEntity(dataContext);
            //this.["FilmCategories"] = new DataViewLocalEntity(dataContext);
            //this.["FilmTexts"] = new DataViewLocalEntity(dataContext);
            //this.["Inventories"] = new DataViewLocalEntity(dataContext);
            //this.["Languages"] = new DataViewLocalEntity(dataContext);
            //this.["Payments"] = new DataViewLocalEntity(dataContext);
            //this.["Rentals"] = new DataViewLocalEntity(dataContext);
            //this.["Staffs"] = new DataViewLocalEntity(dataContext);
            //this.["Stores"] = new DataViewLocalEntity(dataContext);
        }

        public DataViewLocalEntity Actors { get { return this.GetPropertyValue("Actor"); } }
        public DataViewLocalEntity Addresses { get { return this.GetPropertyValue("Address"); } }
        public DataViewLocalEntity Categories { get { return this.GetPropertyValue("Category"); } }
        public DataViewLocalEntity Cities { get { return this.GetPropertyValue("City"); } }
        public DataViewLocalEntity Countries { get { return this.GetPropertyValue("Country"); } }
        public DataViewLocalEntity Customers { get { return this.GetPropertyValue("Customer"); } }
        public DataViewLocalEntity Films { get { return this.GetPropertyValue("Film"); } }
        public DataViewLocalEntity FilmActors { get { return this.GetPropertyValue("FilmActor"); } }
        public DataViewLocalEntity FilmCategories { get { return this.GetPropertyValue("FilmCategory"); } }
        public DataViewLocalEntity FilmTexts { get { return this.GetPropertyValue("FilmText"); } }
        public DataViewLocalEntity Inventories { get { return this.GetPropertyValue("Inventory"); } }
        public DataViewLocalEntity Languages { get { return this.GetPropertyValue("Language"); } }
        public DataViewLocalEntity Payments { get { return this.GetPropertyValue("Payment"); } }
        public DataViewLocalEntity Rentals { get { return this.GetPropertyValue("Rental"); } }
        public DataViewLocalEntity Staffs { get { return this.GetPropertyValue("Staff"); } }
        public DataViewLocalEntity Stores { get { return this.GetPropertyValue("Store"); } }
    }

    public class RemoteEntityViews : RemoteEntityViewsBase
    {
        public RemoteEntityViews(DataViewDto dataViewDto, DataContext dataContext) : base(dataViewDto, dataContext)
        {
            //this.["Actors"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Addresses"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Categories"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Cities"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Countries"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Customers"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Films"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["FilmActors"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["FilmCategories"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["FilmTexts"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Inventories"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Languages"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Payments"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Rentals"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Staffs"] = new DataViewRemoteEntity(dataViewDto, dataContext);
            //this.["Stores"] = new DataViewRemoteEntity(dataViewDto, dataContext);
        }

        public DataViewRemoteEntity Actors { get { return this.GetPropertyValue("Actor"); } }
        public DataViewRemoteEntity Addresses { get { return this.GetPropertyValue("Address"); } }
        public DataViewRemoteEntity Categories { get { return this.GetPropertyValue("Category"); } }
        public DataViewRemoteEntity Cities { get { return this.GetPropertyValue("City"); } }
        public DataViewRemoteEntity Countries { get { return this.GetPropertyValue("Country"); } }
        public DataViewRemoteEntity Customers { get { return this.GetPropertyValue("Customer"); } }
        public DataViewRemoteEntity Films { get { return this.GetPropertyValue("Film"); } }
        public DataViewRemoteEntity FilmActors { get { return this.GetPropertyValue("FilmActor"); } }
        public DataViewRemoteEntity FilmCategories { get { return this.GetPropertyValue("FilmCategory"); } }
        public DataViewRemoteEntity FilmTexts { get { return this.GetPropertyValue("FilmText"); } }
        public DataViewRemoteEntity Inventories { get { return this.GetPropertyValue("Inventory"); } }
        public DataViewRemoteEntity Languages { get { return this.GetPropertyValue("Language"); } }
        public DataViewRemoteEntity Payments { get { return this.GetPropertyValue("Payment"); } }
        public DataViewRemoteEntity Rentals { get { return this.GetPropertyValue("Rental"); } }
        public DataViewRemoteEntity Staffs { get { return this.GetPropertyValue("Staff"); } }
        public DataViewRemoteEntity Stores { get { return this.GetPropertyValue("Store"); } }
    }

    public class LocalDtoViews : LocalDtoViewsBase
    {
        public LocalDtoViews(DataContext dataContext, MetadataSrv.Metadata metadataSrv) : base(dataContext, metadataSrv)
        {
            //this.["Actors"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Addresses"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Categories"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Cities"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Countries"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Customers"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Films"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["FilmActors"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["FilmCategories"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["FilmTexts"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Inventories"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Languages"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Payments"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Rentals"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Staffs"] = new DataViewLocalDto(dataContext, metadataSrv);
            //this.["Stores"] = new DataViewLocalDto(dataContext, metadataSrv);
        }

        public DataViewLocalDto Actors { get { return this.GetPropertyValue("Actor"); } }
        public DataViewLocalDto Addresses { get { return this.GetPropertyValue("Address"); } }
        public DataViewLocalDto Categories { get { return this.GetPropertyValue("Category"); } }
        public DataViewLocalDto Cities { get { return this.GetPropertyValue("City"); } }
        public DataViewLocalDto Countries { get { return this.GetPropertyValue("Country"); } }
        public DataViewLocalDto Customers { get { return this.GetPropertyValue("Customer"); } }
        public DataViewLocalDto Films { get { return this.GetPropertyValue("Film"); } }
        public DataViewLocalDto FilmActors { get { return this.GetPropertyValue("FilmActor"); } }
        public DataViewLocalDto FilmCategories { get { return this.GetPropertyValue("FilmCategory"); } }
        public DataViewLocalDto FilmTexts { get { return this.GetPropertyValue("FilmText"); } }
        public DataViewLocalDto Inventories { get { return this.GetPropertyValue("Inventory"); } }
        public DataViewLocalDto Languages { get { return this.GetPropertyValue("Language"); } }
        public DataViewLocalDto Payments { get { return this.GetPropertyValue("Payment"); } }
        public DataViewLocalDto Rentals { get { return this.GetPropertyValue("Rental"); } }
        public DataViewLocalDto Staffs { get { return this.GetPropertyValue("Staff"); } }
        public DataViewLocalDto Stores { get { return this.GetPropertyValue("Store"); } }
    }

    public class RemoteDtoViews : RemoteDtoViewsBase
    {
        public RemoteDtoViews(DataViewDto dataViewDto) : base(dataViewDto)
        {
            //this.["Actors"] = new DataViewRemoteDto(dataViewDto);
            //this.["Addresses"] = new DataViewRemoteDto(dataViewDto);
            //this.["Categories"] = new DataViewRemoteDto(dataViewDto);
            //this.["Cities"] = new DataViewRemoteDto(dataViewDto);
            //this.["Countries"] = new DataViewRemoteDto(dataViewDto);
            //this.["Customers"] = new DataViewRemoteDto(dataViewDto);
            //this.["Films"] = new DataViewRemoteDto(dataViewDto);
            //this.["FilmActors"] = new DataViewRemoteDto(dataViewDto);
            //this.["FilmCategories"] = new DataViewRemoteDto(dataViewDto);
            //this.["FilmTexts"] = new DataViewRemoteDto(dataViewDto);
            //this.["Inventories"] = new DataViewRemoteDto(dataViewDto);
            //this.["Languages"] = new DataViewRemoteDto(dataViewDto);
            //this.["Payments"] = new DataViewRemoteDto(dataViewDto);
            //this.["Rentals"] = new DataViewRemoteDto(dataViewDto);
            //this.["Staffs"] = new DataViewRemoteDto(dataViewDto);
            //this.["Stores"] = new DataViewRemoteDto(dataViewDto);
        }

        public DataViewRemoteDto Actors { get { return this.GetPropertyValue("Actor"); } }
        public DataViewRemoteDto Addresses { get { return this.GetPropertyValue("Address"); } }
        public DataViewRemoteDto Categories { get { return this.GetPropertyValue("Category"); } }
        public DataViewRemoteDto Cities { get { return this.GetPropertyValue("City"); } }
        public DataViewRemoteDto Countries { get { return this.GetPropertyValue("Country"); } }
        public DataViewRemoteDto Customers { get { return this.GetPropertyValue("Customer"); } }
        public DataViewRemoteDto Films { get { return this.GetPropertyValue("Film"); } }
        public DataViewRemoteDto FilmActors { get { return this.GetPropertyValue("FilmActor"); } }
        public DataViewRemoteDto FilmCategories { get { return this.GetPropertyValue("FilmCategory"); } }
        public DataViewRemoteDto FilmTexts { get { return this.GetPropertyValue("FilmText"); } }
        public DataViewRemoteDto Inventories { get { return this.GetPropertyValue("Inventory"); } }
        public DataViewRemoteDto Languages { get { return this.GetPropertyValue("Language"); } }
        public DataViewRemoteDto Payments { get { return this.GetPropertyValue("Payment"); } }
        public DataViewRemoteDto Rentals { get { return this.GetPropertyValue("Rental"); } }
        public DataViewRemoteDto Staffs { get { return this.GetPropertyValue("Staff"); } }
        public DataViewRemoteDto Stores { get { return this.GetPropertyValue("Store"); } }
    }

    public sealed class Actor
    {
        public Actor(Entity entity)
        {
            if (entity.entityTypeName != "Actor") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short ActorId { get { return (short)this.entity.dto["ActorId"]; } set { this.entity.dto["ActorId"] = value; } }
        public string FirstName { get { return (string)this.entity.dto["FirstName"]; } set { this.entity.dto["FirstName"] = value; } }
        public string LastName { get { return (string)this.entity.dto["LastName"]; } set { this.entity.dto["LastName"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<FilmActor> FilmActors { get { return this.entity.NavigateMulti("Actor", "FilmActors").Select( it => new FilmActor(it) ); } }
        
    }

    public sealed class Address
    {
        public Address(Entity entity)
        {
            if (entity.entityTypeName != "Address") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short AddressId { get { return (short)this.entity.dto["AddressId"]; } set { this.entity.dto["AddressId"] = value; } }
        public string Address1 { get { return (string)this.entity.dto["Address1"]; } set { this.entity.dto["Address1"] = value; } }
        public string Address2 { get { return (string)this.entity.dto["Address2"]; } set { this.entity.dto["Address2"] = value; } }
        public string District { get { return (string)this.entity.dto["District"]; } set { this.entity.dto["District"] = value; } }
        public short CityId { get { return (short)this.entity.dto["CityId"]; } set { this.entity.dto["CityId"] = value; } }
        public string PostalCode { get { return (string)this.entity.dto["PostalCode"]; } set { this.entity.dto["PostalCode"] = value; } }
        public string Phone { get { return (string)this.entity.dto["Phone"]; } set { this.entity.dto["Phone"] = value; } }
        public object Location { get { return (object)this.entity.dto["Location"]; } set { this.entity.dto["Location"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public City City { get { var it = this.entity.NavigateSingle("Address", "City"); if (it != null) { return new City(it); } else { return null; } } }
        [JsonIgnore]
        public IEnumerable<Customer> Customers { get { return this.entity.NavigateMulti("Address", "Customers").Select( it => new Customer(it) ); } }
        [JsonIgnore]
        public IEnumerable<Staff> Staffs { get { return this.entity.NavigateMulti("Address", "Staffs").Select( it => new Staff(it) ); } }
        [JsonIgnore]
        public IEnumerable<Store> Stores { get { return this.entity.NavigateMulti("Address", "Stores").Select( it => new Store(it) ); } }
        
    }

    public sealed class Category
    {
        public Category(Entity entity)
        {
            if (entity.entityTypeName != "Category") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public sbyte CategoryId { get { return (sbyte)this.entity.dto["CategoryId"]; } set { this.entity.dto["CategoryId"] = value; } }
        public string Name { get { return (string)this.entity.dto["Name"]; } set { this.entity.dto["Name"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<FilmCategory> FilmCategories { get { return this.entity.NavigateMulti("Category", "FilmCategories").Select( it => new FilmCategory(it) ); } }
        
    }

    public sealed class City
    {
        public City(Entity entity)
        {
            if (entity.entityTypeName != "City") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short CityId { get { return (short)this.entity.dto["CityId"]; } set { this.entity.dto["CityId"] = value; } }
        public string Name { get { return (string)this.entity.dto["Name"]; } set { this.entity.dto["Name"] = value; } }
        public short CountryId { get { return (short)this.entity.dto["CountryId"]; } set { this.entity.dto["CountryId"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<Address> Addresses { get { return this.entity.NavigateMulti("City", "Addresses").Select( it => new Address(it) ); } }
        [JsonIgnore]
        public Country Country { get { var it = this.entity.NavigateSingle("City", "Country"); if (it != null) { return new Country(it); } else { return null; } } }
        
    }

    public sealed class Country
    {
        public Country(Entity entity)
        {
            if (entity.entityTypeName != "Country") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short CountryId { get { return (short)this.entity.dto["CountryId"]; } set { this.entity.dto["CountryId"] = value; } }
        public string Name { get { return (string)this.entity.dto["Name"]; } set { this.entity.dto["Name"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<City> Cities { get { return this.entity.NavigateMulti("Country", "Cities").Select( it => new City(it) ); } }
        
    }

    public sealed class Customer
    {
        public Customer(Entity entity)
        {
            if (entity.entityTypeName != "Customer") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short CustomerId { get { return (short)this.entity.dto["CustomerId"]; } set { this.entity.dto["CustomerId"] = value; } }
        public sbyte StoreId { get { return (sbyte)this.entity.dto["StoreId"]; } set { this.entity.dto["StoreId"] = value; } }
        public string FirstName { get { return (string)this.entity.dto["FirstName"]; } set { this.entity.dto["FirstName"] = value; } }
        public string LastName { get { return (string)this.entity.dto["LastName"]; } set { this.entity.dto["LastName"] = value; } }
        public string Email { get { return (string)this.entity.dto["Email"]; } set { this.entity.dto["Email"] = value; } }
        public short AddressId { get { return (short)this.entity.dto["AddressId"]; } set { this.entity.dto["AddressId"] = value; } }
        public bool Active { get { return (bool)this.entity.dto["Active"]; } set { this.entity.dto["Active"] = value; } }
        public DateTime CreateDate { get { return (DateTime)this.entity.dto["CreateDate"]; } set { this.entity.dto["CreateDate"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public Store Store { get { var it = this.entity.NavigateSingle("Customer", "Store"); if (it != null) { return new Store(it); } else { return null; } } }
        [JsonIgnore]
        public Address Address { get { var it = this.entity.NavigateSingle("Customer", "Address"); if (it != null) { return new Address(it); } else { return null; } } }
        [JsonIgnore]
        public IEnumerable<Payment> Payments { get { return this.entity.NavigateMulti("Customer", "Payments").Select( it => new Payment(it) ); } }
        [JsonIgnore]
        public IEnumerable<Rental> Rentals { get { return this.entity.NavigateMulti("Customer", "Rentals").Select( it => new Rental(it) ); } }
        
    }

    public sealed class Film
    {
        public Film(Entity entity)
        {
            if (entity.entityTypeName != "Film") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short FilmId { get { return (short)this.entity.dto["FilmId"]; } set { this.entity.dto["FilmId"] = value; } }
        public string Title { get { return (string)this.entity.dto["Title"]; } set { this.entity.dto["Title"] = value; } }
        public string Description { get { return (string)this.entity.dto["Description"]; } set { this.entity.dto["Description"] = value; } }
        public ushort? ReleaseYear { get { return (ushort?)this.entity.dto["ReleaseYear"]; } set { this.entity.dto["ReleaseYear"] = value; } }
        public sbyte LanguageId { get { return (sbyte)this.entity.dto["LanguageId"]; } set { this.entity.dto["LanguageId"] = value; } }
        public sbyte? OriginalLanguageId { get { return (sbyte?)this.entity.dto["OriginalLanguageId"]; } set { this.entity.dto["OriginalLanguageId"] = value; } }
        public sbyte RentalDuration { get { return (sbyte)this.entity.dto["RentalDuration"]; } set { this.entity.dto["RentalDuration"] = value; } }
        public float RentalRate { get { return (float)this.entity.dto["RentalRate"]; } set { this.entity.dto["RentalRate"] = value; } }
        public short? Length { get { return (short?)this.entity.dto["Length"]; } set { this.entity.dto["Length"] = value; } }
        public float ReplacementCost { get { return (float)this.entity.dto["ReplacementCost"]; } set { this.entity.dto["ReplacementCost"] = value; } }
        public string Rating { get { return (string)this.entity.dto["Rating"]; } set { this.entity.dto["Rating"] = value; } }
        public string SpecialFeatures { get { return (string)this.entity.dto["SpecialFeatures"]; } set { this.entity.dto["SpecialFeatures"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public Language Language { get { var it = this.entity.NavigateSingle("Film", "Language"); if (it != null) { return new Language(it); } else { return null; } } }
        [JsonIgnore]
        public Language Language1 { get { var it = this.entity.NavigateSingle("Film", "Language1"); if (it != null) { return new Language(it); } else { return null; } } }
        [JsonIgnore]
        public IEnumerable<FilmActor> FilmActors { get { return this.entity.NavigateMulti("Film", "FilmActors").Select( it => new FilmActor(it) ); } }
        [JsonIgnore]
        public IEnumerable<FilmCategory> FilmCategories { get { return this.entity.NavigateMulti("Film", "FilmCategories").Select( it => new FilmCategory(it) ); } }
        [JsonIgnore]
        public IEnumerable<Inventory> Inventories { get { return this.entity.NavigateMulti("Film", "Inventories").Select( it => new Inventory(it) ); } }
        
    }

    public sealed class FilmActor
    {
        public FilmActor(Entity entity)
        {
            if (entity.entityTypeName != "FilmActor") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short ActorId { get { return (short)this.entity.dto["ActorId"]; } set { this.entity.dto["ActorId"] = value; } }
        public short FilmId { get { return (short)this.entity.dto["FilmId"]; } set { this.entity.dto["FilmId"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public Actor Actor { get { var it = this.entity.NavigateSingle("FilmActor", "Actor"); if (it != null) { return new Actor(it); } else { return null; } } }
        [JsonIgnore]
        public Film Film { get { var it = this.entity.NavigateSingle("FilmActor", "Film"); if (it != null) { return new Film(it); } else { return null; } } }
        
    }

    public sealed class FilmCategory
    {
        public FilmCategory(Entity entity)
        {
            if (entity.entityTypeName != "FilmCategory") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short FilmId { get { return (short)this.entity.dto["FilmId"]; } set { this.entity.dto["FilmId"] = value; } }
        public sbyte CategoryId { get { return (sbyte)this.entity.dto["CategoryId"]; } set { this.entity.dto["CategoryId"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public Film Film { get { var it = this.entity.NavigateSingle("FilmCategory", "Film"); if (it != null) { return new Film(it); } else { return null; } } }
        [JsonIgnore]
        public Category Category { get { var it = this.entity.NavigateSingle("FilmCategory", "Category"); if (it != null) { return new Category(it); } else { return null; } } }
        
    }

    public sealed class FilmText
    {
        public FilmText(Entity entity)
        {
            if (entity.entityTypeName != "FilmText") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short FilmId { get { return (short)this.entity.dto["FilmId"]; } set { this.entity.dto["FilmId"] = value; } }
        public string Title { get { return (string)this.entity.dto["Title"]; } set { this.entity.dto["Title"] = value; } }
        public string Description { get { return (string)this.entity.dto["Description"]; } set { this.entity.dto["Description"] = value; } }
        
        
    }

    public sealed class Inventory
    {
        public Inventory(Entity entity)
        {
            if (entity.entityTypeName != "Inventory") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public int InventoryId { get { return (int)this.entity.dto["InventoryId"]; } set { this.entity.dto["InventoryId"] = value; } }
        public short FilmId { get { return (short)this.entity.dto["FilmId"]; } set { this.entity.dto["FilmId"] = value; } }
        public sbyte StoreId { get { return (sbyte)this.entity.dto["StoreId"]; } set { this.entity.dto["StoreId"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public Film Film { get { var it = this.entity.NavigateSingle("Inventory", "Film"); if (it != null) { return new Film(it); } else { return null; } } }
        [JsonIgnore]
        public Store Store { get { var it = this.entity.NavigateSingle("Inventory", "Store"); if (it != null) { return new Store(it); } else { return null; } } }
        [JsonIgnore]
        public IEnumerable<Rental> Rentals { get { return this.entity.NavigateMulti("Inventory", "Rentals").Select( it => new Rental(it) ); } }
        
    }

    public sealed class Language
    {
        public Language(Entity entity)
        {
            if (entity.entityTypeName != "Language") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public sbyte LanguageId { get { return (sbyte)this.entity.dto["LanguageId"]; } set { this.entity.dto["LanguageId"] = value; } }
        public string Name { get { return (string)this.entity.dto["Name"]; } set { this.entity.dto["Name"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<Film> Films { get { return this.entity.NavigateMulti("Language", "Films").Select( it => new Film(it) ); } }
        [JsonIgnore]
        public IEnumerable<Film> Films1 { get { return this.entity.NavigateMulti("Language", "Films1").Select( it => new Film(it) ); } }
        
    }

    public sealed class Payment
    {
        public Payment(Entity entity)
        {
            if (entity.entityTypeName != "Payment") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public short PaymentId { get { return (short)this.entity.dto["PaymentId"]; } set { this.entity.dto["PaymentId"] = value; } }
        public short CustomerId { get { return (short)this.entity.dto["CustomerId"]; } set { this.entity.dto["CustomerId"] = value; } }
        public sbyte StaffId { get { return (sbyte)this.entity.dto["StaffId"]; } set { this.entity.dto["StaffId"] = value; } }
        public int? RentalId { get { return (int?)this.entity.dto["RentalId"]; } set { this.entity.dto["RentalId"] = value; } }
        public float Amount { get { return (float)this.entity.dto["Amount"]; } set { this.entity.dto["Amount"] = value; } }
        public DateTime PaymentDate { get { return (DateTime)this.entity.dto["PaymentDate"]; } set { this.entity.dto["PaymentDate"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public Customer Customer { get { var it = this.entity.NavigateSingle("Payment", "Customer"); if (it != null) { return new Customer(it); } else { return null; } } }
        [JsonIgnore]
        public Staff Staff { get { var it = this.entity.NavigateSingle("Payment", "Staff"); if (it != null) { return new Staff(it); } else { return null; } } }
        [JsonIgnore]
        public Rental Rental { get { var it = this.entity.NavigateSingle("Payment", "Rental"); if (it != null) { return new Rental(it); } else { return null; } } }
        
    }

    public sealed class Rental
    {
        public Rental(Entity entity)
        {
            if (entity.entityTypeName != "Rental") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public int RentalId { get { return (int)this.entity.dto["RentalId"]; } set { this.entity.dto["RentalId"] = value; } }
        public DateTime RentalDate { get { return (DateTime)this.entity.dto["RentalDate"]; } set { this.entity.dto["RentalDate"] = value; } }
        public int InventoryId { get { return (int)this.entity.dto["InventoryId"]; } set { this.entity.dto["InventoryId"] = value; } }
        public short CustomerId { get { return (short)this.entity.dto["CustomerId"]; } set { this.entity.dto["CustomerId"] = value; } }
        public DateTime? ReturnDate { get { return (DateTime?)this.entity.dto["ReturnDate"]; } set { this.entity.dto["ReturnDate"] = value; } }
        public sbyte StaffId { get { return (sbyte)this.entity.dto["StaffId"]; } set { this.entity.dto["StaffId"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<Payment> Payments { get { return this.entity.NavigateMulti("Rental", "Payments").Select( it => new Payment(it) ); } }
        [JsonIgnore]
        public Inventory Inventory { get { var it = this.entity.NavigateSingle("Rental", "Inventory"); if (it != null) { return new Inventory(it); } else { return null; } } }
        [JsonIgnore]
        public Customer Customer { get { var it = this.entity.NavigateSingle("Rental", "Customer"); if (it != null) { return new Customer(it); } else { return null; } } }
        [JsonIgnore]
        public Staff Staff { get { var it = this.entity.NavigateSingle("Rental", "Staff"); if (it != null) { return new Staff(it); } else { return null; } } }
        
    }

    public sealed class Staff
    {
        public Staff(Entity entity)
        {
            if (entity.entityTypeName != "Staff") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public sbyte StaffId { get { return (sbyte)this.entity.dto["StaffId"]; } set { this.entity.dto["StaffId"] = value; } }
        public string FirstName { get { return (string)this.entity.dto["FirstName"]; } set { this.entity.dto["FirstName"] = value; } }
        public string LastName { get { return (string)this.entity.dto["LastName"]; } set { this.entity.dto["LastName"] = value; } }
        public short AddressId { get { return (short)this.entity.dto["AddressId"]; } set { this.entity.dto["AddressId"] = value; } }
        public byte[] Picture { get { return (byte[])this.entity.dto["Picture"]; } set { this.entity.dto["Picture"] = value; } }
        public string Email { get { return (string)this.entity.dto["Email"]; } set { this.entity.dto["Email"] = value; } }
        public sbyte StoreId { get { return (sbyte)this.entity.dto["StoreId"]; } set { this.entity.dto["StoreId"] = value; } }
        public bool Active { get { return (bool)this.entity.dto["Active"]; } set { this.entity.dto["Active"] = value; } }
        public string Username { get { return (string)this.entity.dto["Username"]; } set { this.entity.dto["Username"] = value; } }
        public string Password { get { return (string)this.entity.dto["Password"]; } set { this.entity.dto["Password"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<Payment> Payments { get { return this.entity.NavigateMulti("Staff", "Payments").Select( it => new Payment(it) ); } }
        [JsonIgnore]
        public IEnumerable<Rental> Rentals { get { return this.entity.NavigateMulti("Staff", "Rentals").Select( it => new Rental(it) ); } }
        [JsonIgnore]
        public Address Address { get { var it = this.entity.NavigateSingle("Staff", "Address"); if (it != null) { return new Address(it); } else { return null; } } }
        [JsonIgnore]
        public Store Store { get { var it = this.entity.NavigateSingle("Staff", "Store"); if (it != null) { return new Store(it); } else { return null; } } }
        [JsonIgnore]
        public IEnumerable<Store> Stores { get { return this.entity.NavigateMulti("Staff", "Stores").Select( it => new Store(it) ); } }
        
    }

    public sealed class Store
    {
        public Store(Entity entity)
        {
            if (entity.entityTypeName != "Store") { throw new ArgumentException("Incorrect entity type"); }
            this.entity = entity;
        }

        public Entity entity { get; private set; }
        
        public sbyte StoreId { get { return (sbyte)this.entity.dto["StoreId"]; } set { this.entity.dto["StoreId"] = value; } }
        public sbyte ManagerStaffId { get { return (sbyte)this.entity.dto["ManagerStaffId"]; } set { this.entity.dto["ManagerStaffId"] = value; } }
        public short AddressId { get { return (short)this.entity.dto["AddressId"]; } set { this.entity.dto["AddressId"] = value; } }
        public DateTime LastUpdate { get { return (DateTime)this.entity.dto["LastUpdate"]; } set { this.entity.dto["LastUpdate"] = value; } }
        
        [JsonIgnore]
        public IEnumerable<Customer> Customers { get { return this.entity.NavigateMulti("Store", "Customers").Select( it => new Customer(it) ); } }
        [JsonIgnore]
        public IEnumerable<Inventory> Inventories { get { return this.entity.NavigateMulti("Store", "Inventories").Select( it => new Inventory(it) ); } }
        [JsonIgnore]
        public IEnumerable<Staff> Staffs { get { return this.entity.NavigateMulti("Store", "Staffs").Select( it => new Staff(it) ); } }
        [JsonIgnore]
        public Staff Staff { get { var it = this.entity.NavigateSingle("Store", "Staff"); if (it != null) { return new Staff(it); } else { return null; } } }
        [JsonIgnore]
        public Address Address { get { var it = this.entity.NavigateSingle("Store", "Address"); if (it != null) { return new Address(it); } else { return null; } } }
        
    }

}

#pragma warning restore SA1649, SA1128, SA1005, SA1516, SA1402, SA1028, SA1119, SA1507, SA1502, SA1508, SA1122, SA1633, SA1300
