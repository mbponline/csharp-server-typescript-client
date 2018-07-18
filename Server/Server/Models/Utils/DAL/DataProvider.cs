#pragma warning disable SA1649, SA1128, SA1005, SA1516, SA1402, SA1028, SA1119, SA1507, SA1502, SA1508, SA1122, SA1633, SA1300

//------------------------------------------------------------------------------
//    This code was auto-generated.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//------------------------------------------------------------------------------

using Newtonsoft.Json;
using Server.Models.Utils.DAL.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Hosting;
using MetadataSrv = Server.Models.Utils.DAL.Common.MetadataSrv;

namespace Server.Models.Utils.DAL
{
    public class DataService : DataServiceEntity<LocalEntityViews, LocalDtoViews, RemoteEntityViews, RemoteDtoViews>
    {
        public DataService(string metadataFileName = "", string connectionString = "") : base(metadataFileName, connectionString)
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
            //this.["Actors"] = new DataViewLocalEntity<Actor>(dataContext);
            //this.["Addresses"] = new DataViewLocalEntity<Address>(dataContext);
            //this.["Categories"] = new DataViewLocalEntity<Category>(dataContext);
            //this.["Cities"] = new DataViewLocalEntity<City>(dataContext);
            //this.["Countries"] = new DataViewLocalEntity<Country>(dataContext);
            //this.["Customers"] = new DataViewLocalEntity<Customer>(dataContext);
            //this.["Films"] = new DataViewLocalEntity<Film>(dataContext);
            //this.["FilmActors"] = new DataViewLocalEntity<FilmActor>(dataContext);
            //this.["FilmCategories"] = new DataViewLocalEntity<FilmCategory>(dataContext);
            //this.["FilmTexts"] = new DataViewLocalEntity<FilmText>(dataContext);
            //this.["Inventories"] = new DataViewLocalEntity<Inventory>(dataContext);
            //this.["Languages"] = new DataViewLocalEntity<Language>(dataContext);
            //this.["Payments"] = new DataViewLocalEntity<Payment>(dataContext);
            //this.["Rentals"] = new DataViewLocalEntity<Rental>(dataContext);
            //this.["Staffs"] = new DataViewLocalEntity<Staff>(dataContext);
            //this.["Stores"] = new DataViewLocalEntity<Store>(dataContext);
        }

        public DataViewLocalEntity<Actor> Actors { get { return this.GetPropertyValue<Actor>(); } }
        public DataViewLocalEntity<Address> Addresses { get { return this.GetPropertyValue<Address>(); } }
        public DataViewLocalEntity<Category> Categories { get { return this.GetPropertyValue<Category>(); } }
        public DataViewLocalEntity<City> Cities { get { return this.GetPropertyValue<City>(); } }
        public DataViewLocalEntity<Country> Countries { get { return this.GetPropertyValue<Country>(); } }
        public DataViewLocalEntity<Customer> Customers { get { return this.GetPropertyValue<Customer>(); } }
        public DataViewLocalEntity<Film> Films { get { return this.GetPropertyValue<Film>(); } }
        public DataViewLocalEntity<FilmActor> FilmActors { get { return this.GetPropertyValue<FilmActor>(); } }
        public DataViewLocalEntity<FilmCategory> FilmCategories { get { return this.GetPropertyValue<FilmCategory>(); } }
        public DataViewLocalEntity<FilmText> FilmTexts { get { return this.GetPropertyValue<FilmText>(); } }
        public DataViewLocalEntity<Inventory> Inventories { get { return this.GetPropertyValue<Inventory>(); } }
        public DataViewLocalEntity<Language> Languages { get { return this.GetPropertyValue<Language>(); } }
        public DataViewLocalEntity<Payment> Payments { get { return this.GetPropertyValue<Payment>(); } }
        public DataViewLocalEntity<Rental> Rentals { get { return this.GetPropertyValue<Rental>(); } }
        public DataViewLocalEntity<Staff> Staffs { get { return this.GetPropertyValue<Staff>(); } }
        public DataViewLocalEntity<Store> Stores { get { return this.GetPropertyValue<Store>(); } }
    }

    public class RemoteEntityViews : RemoteEntityViewsBase
    {
        public RemoteEntityViews(DataViewDto dataViewDto, DataContext dataContext) : base(dataViewDto, dataContext)
        {
            //this.["Actors"] = new DataViewRemoteEntity<Actor>(dataViewDto, dataContext);
            //this.["Addresses"] = new DataViewRemoteEntity<Address>(dataViewDto, dataContext);
            //this.["Categories"] = new DataViewRemoteEntity<Category>(dataViewDto, dataContext);
            //this.["Cities"] = new DataViewRemoteEntity<City>(dataViewDto, dataContext);
            //this.["Countries"] = new DataViewRemoteEntity<Country>(dataViewDto, dataContext);
            //this.["Customers"] = new DataViewRemoteEntity<Customer>(dataViewDto, dataContext);
            //this.["Films"] = new DataViewRemoteEntity<Film>(dataViewDto, dataContext);
            //this.["FilmActors"] = new DataViewRemoteEntity<FilmActor>(dataViewDto, dataContext);
            //this.["FilmCategories"] = new DataViewRemoteEntity<FilmCategory>(dataViewDto, dataContext);
            //this.["FilmTexts"] = new DataViewRemoteEntity<FilmText>(dataViewDto, dataContext);
            //this.["Inventories"] = new DataViewRemoteEntity<Inventory>(dataViewDto, dataContext);
            //this.["Languages"] = new DataViewRemoteEntity<Language>(dataViewDto, dataContext);
            //this.["Payments"] = new DataViewRemoteEntity<Payment>(dataViewDto, dataContext);
            //this.["Rentals"] = new DataViewRemoteEntity<Rental>(dataViewDto, dataContext);
            //this.["Staffs"] = new DataViewRemoteEntity<Staff>(dataViewDto, dataContext);
            //this.["Stores"] = new DataViewRemoteEntity<Store>(dataViewDto, dataContext);
        }

        public DataViewRemoteEntity<Actor> Actors { get { return this.GetPropertyValue<Actor>(); } }
        public DataViewRemoteEntity<Address> Addresses { get { return this.GetPropertyValue<Address>(); } }
        public DataViewRemoteEntity<Category> Categories { get { return this.GetPropertyValue<Category>(); } }
        public DataViewRemoteEntity<City> Cities { get { return this.GetPropertyValue<City>(); } }
        public DataViewRemoteEntity<Country> Countries { get { return this.GetPropertyValue<Country>(); } }
        public DataViewRemoteEntity<Customer> Customers { get { return this.GetPropertyValue<Customer>(); } }
        public DataViewRemoteEntity<Film> Films { get { return this.GetPropertyValue<Film>(); } }
        public DataViewRemoteEntity<FilmActor> FilmActors { get { return this.GetPropertyValue<FilmActor>(); } }
        public DataViewRemoteEntity<FilmCategory> FilmCategories { get { return this.GetPropertyValue<FilmCategory>(); } }
        public DataViewRemoteEntity<FilmText> FilmTexts { get { return this.GetPropertyValue<FilmText>(); } }
        public DataViewRemoteEntity<Inventory> Inventories { get { return this.GetPropertyValue<Inventory>(); } }
        public DataViewRemoteEntity<Language> Languages { get { return this.GetPropertyValue<Language>(); } }
        public DataViewRemoteEntity<Payment> Payments { get { return this.GetPropertyValue<Payment>(); } }
        public DataViewRemoteEntity<Rental> Rentals { get { return this.GetPropertyValue<Rental>(); } }
        public DataViewRemoteEntity<Staff> Staffs { get { return this.GetPropertyValue<Staff>(); } }
        public DataViewRemoteEntity<Store> Stores { get { return this.GetPropertyValue<Store>(); } }
    }

    public class LocalDtoViews : LocalDtoViewsBase
    {
        public LocalDtoViews(DataContext dataContext, MetadataSrv.Metadata metadataSrv) : base(dataContext, metadataSrv)
        {
            //this.["Actors"] = new DataViewLocalDto<Actor>(dataContext, metadataSrv);
            //this.["Addresses"] = new DataViewLocalDto<Address>(dataContext, metadataSrv);
            //this.["Categories"] = new DataViewLocalDto<Category>(dataContext, metadataSrv);
            //this.["Cities"] = new DataViewLocalDto<City>(dataContext, metadataSrv);
            //this.["Countries"] = new DataViewLocalDto<Country>(dataContext, metadataSrv);
            //this.["Customers"] = new DataViewLocalDto<Customer>(dataContext, metadataSrv);
            //this.["Films"] = new DataViewLocalDto<Film>(dataContext, metadataSrv);
            //this.["FilmActors"] = new DataViewLocalDto<FilmActor>(dataContext, metadataSrv);
            //this.["FilmCategories"] = new DataViewLocalDto<FilmCategory>(dataContext, metadataSrv);
            //this.["FilmTexts"] = new DataViewLocalDto<FilmText>(dataContext, metadataSrv);
            //this.["Inventories"] = new DataViewLocalDto<Inventory>(dataContext, metadataSrv);
            //this.["Languages"] = new DataViewLocalDto<Language>(dataContext, metadataSrv);
            //this.["Payments"] = new DataViewLocalDto<Payment>(dataContext, metadataSrv);
            //this.["Rentals"] = new DataViewLocalDto<Rental>(dataContext, metadataSrv);
            //this.["Staffs"] = new DataViewLocalDto<Staff>(dataContext, metadataSrv);
            //this.["Stores"] = new DataViewLocalDto<Store>(dataContext, metadataSrv);
        }

        public DataViewLocalDto<Actor> Actors { get { return this.GetPropertyValue<Actor>(); } }
        public DataViewLocalDto<Address> Addresses { get { return this.GetPropertyValue<Address>(); } }
        public DataViewLocalDto<Category> Categories { get { return this.GetPropertyValue<Category>(); } }
        public DataViewLocalDto<City> Cities { get { return this.GetPropertyValue<City>(); } }
        public DataViewLocalDto<Country> Countries { get { return this.GetPropertyValue<Country>(); } }
        public DataViewLocalDto<Customer> Customers { get { return this.GetPropertyValue<Customer>(); } }
        public DataViewLocalDto<Film> Films { get { return this.GetPropertyValue<Film>(); } }
        public DataViewLocalDto<FilmActor> FilmActors { get { return this.GetPropertyValue<FilmActor>(); } }
        public DataViewLocalDto<FilmCategory> FilmCategories { get { return this.GetPropertyValue<FilmCategory>(); } }
        public DataViewLocalDto<FilmText> FilmTexts { get { return this.GetPropertyValue<FilmText>(); } }
        public DataViewLocalDto<Inventory> Inventories { get { return this.GetPropertyValue<Inventory>(); } }
        public DataViewLocalDto<Language> Languages { get { return this.GetPropertyValue<Language>(); } }
        public DataViewLocalDto<Payment> Payments { get { return this.GetPropertyValue<Payment>(); } }
        public DataViewLocalDto<Rental> Rentals { get { return this.GetPropertyValue<Rental>(); } }
        public DataViewLocalDto<Staff> Staffs { get { return this.GetPropertyValue<Staff>(); } }
        public DataViewLocalDto<Store> Stores { get { return this.GetPropertyValue<Store>(); } }
    }

    public class RemoteDtoViews : RemoteDtoViewsBase
    {
        public RemoteDtoViews(DataViewDto dataViewDto) : base(dataViewDto)
        {
            //this.["Actors"] = new DataViewRemoteDto<Actor>(dataViewDto);
            //this.["Addresses"] = new DataViewRemoteDto<Address>(dataViewDto);
            //this.["Categories"] = new DataViewRemoteDto<Category>(dataViewDto);
            //this.["Cities"] = new DataViewRemoteDto<City>(dataViewDto);
            //this.["Countries"] = new DataViewRemoteDto<Country>(dataViewDto);
            //this.["Customers"] = new DataViewRemoteDto<Customer>(dataViewDto);
            //this.["Films"] = new DataViewRemoteDto<Film>(dataViewDto);
            //this.["FilmActors"] = new DataViewRemoteDto<FilmActor>(dataViewDto);
            //this.["FilmCategories"] = new DataViewRemoteDto<FilmCategory>(dataViewDto);
            //this.["FilmTexts"] = new DataViewRemoteDto<FilmText>(dataViewDto);
            //this.["Inventories"] = new DataViewRemoteDto<Inventory>(dataViewDto);
            //this.["Languages"] = new DataViewRemoteDto<Language>(dataViewDto);
            //this.["Payments"] = new DataViewRemoteDto<Payment>(dataViewDto);
            //this.["Rentals"] = new DataViewRemoteDto<Rental>(dataViewDto);
            //this.["Staffs"] = new DataViewRemoteDto<Staff>(dataViewDto);
            //this.["Stores"] = new DataViewRemoteDto<Store>(dataViewDto);
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

    public sealed class Actor : IDerivedEntity
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
        public IEnumerable<FilmActor> FilmActors { get { return this.entity.NavigateMulti<FilmActor>("Actor", "FilmActors"); } }
        
    }

    public sealed class Address : IDerivedEntity
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
        public City City { get { return this.entity.NavigateSingle<City>("Address", "City"); } }
        [JsonIgnore]
        public IEnumerable<Customer> Customers { get { return this.entity.NavigateMulti<Customer>("Address", "Customers"); } }
        [JsonIgnore]
        public IEnumerable<Staff> Staffs { get { return this.entity.NavigateMulti<Staff>("Address", "Staffs"); } }
        [JsonIgnore]
        public IEnumerable<Store> Stores { get { return this.entity.NavigateMulti<Store>("Address", "Stores"); } }
        
    }

    public sealed class Category : IDerivedEntity
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
        public IEnumerable<FilmCategory> FilmCategories { get { return this.entity.NavigateMulti<FilmCategory>("Category", "FilmCategories"); } }
        
    }

    public sealed class City : IDerivedEntity
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
        public IEnumerable<Address> Addresses { get { return this.entity.NavigateMulti<Address>("City", "Addresses"); } }
        [JsonIgnore]
        public Country Country { get { return this.entity.NavigateSingle<Country>("City", "Country"); } }
        
    }

    public sealed class Country : IDerivedEntity
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
        public IEnumerable<City> Cities { get { return this.entity.NavigateMulti<City>("Country", "Cities"); } }
        
    }

    public sealed class Customer : IDerivedEntity
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
        public Store Store { get { return this.entity.NavigateSingle<Store>("Customer", "Store"); } }
        [JsonIgnore]
        public Address Address { get { return this.entity.NavigateSingle<Address>("Customer", "Address"); } }
        [JsonIgnore]
        public IEnumerable<Payment> Payments { get { return this.entity.NavigateMulti<Payment>("Customer", "Payments"); } }
        [JsonIgnore]
        public IEnumerable<Rental> Rentals { get { return this.entity.NavigateMulti<Rental>("Customer", "Rentals"); } }
        
    }

    public sealed class Film : IDerivedEntity
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
        public Language Language { get { return this.entity.NavigateSingle<Language>("Film", "Language"); } }
        [JsonIgnore]
        public Language Language1 { get { return this.entity.NavigateSingle<Language>("Film", "Language1"); } }
        [JsonIgnore]
        public IEnumerable<FilmActor> FilmActors { get { return this.entity.NavigateMulti<FilmActor>("Film", "FilmActors"); } }
        [JsonIgnore]
        public IEnumerable<FilmCategory> FilmCategories { get { return this.entity.NavigateMulti<FilmCategory>("Film", "FilmCategories"); } }
        [JsonIgnore]
        public IEnumerable<Inventory> Inventories { get { return this.entity.NavigateMulti<Inventory>("Film", "Inventories"); } }
        
    }

    public sealed class FilmActor : IDerivedEntity
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
        public Actor Actor { get { return this.entity.NavigateSingle<Actor>("FilmActor", "Actor"); } }
        [JsonIgnore]
        public Film Film { get { return this.entity.NavigateSingle<Film>("FilmActor", "Film"); } }
        
    }

    public sealed class FilmCategory : IDerivedEntity
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
        public Film Film { get { return this.entity.NavigateSingle<Film>("FilmCategory", "Film"); } }
        [JsonIgnore]
        public Category Category { get { return this.entity.NavigateSingle<Category>("FilmCategory", "Category"); } }
        
    }

    public sealed class FilmText : IDerivedEntity
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

    public sealed class Inventory : IDerivedEntity
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
        public Film Film { get { return this.entity.NavigateSingle<Film>("Inventory", "Film"); } }
        [JsonIgnore]
        public Store Store { get { return this.entity.NavigateSingle<Store>("Inventory", "Store"); } }
        [JsonIgnore]
        public IEnumerable<Rental> Rentals { get { return this.entity.NavigateMulti<Rental>("Inventory", "Rentals"); } }
        
    }

    public sealed class Language : IDerivedEntity
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
        public IEnumerable<Film> Films { get { return this.entity.NavigateMulti<Film>("Language", "Films"); } }
        [JsonIgnore]
        public IEnumerable<Film> Films1 { get { return this.entity.NavigateMulti<Film>("Language", "Films1"); } }
        
    }

    public sealed class Payment : IDerivedEntity
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
        public Customer Customer { get { return this.entity.NavigateSingle<Customer>("Payment", "Customer"); } }
        [JsonIgnore]
        public Staff Staff { get { return this.entity.NavigateSingle<Staff>("Payment", "Staff"); } }
        [JsonIgnore]
        public Rental Rental { get { return this.entity.NavigateSingle<Rental>("Payment", "Rental"); } }
        
    }

    public sealed class Rental : IDerivedEntity
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
        public IEnumerable<Payment> Payments { get { return this.entity.NavigateMulti<Payment>("Rental", "Payments"); } }
        [JsonIgnore]
        public Inventory Inventory { get { return this.entity.NavigateSingle<Inventory>("Rental", "Inventory"); } }
        [JsonIgnore]
        public Customer Customer { get { return this.entity.NavigateSingle<Customer>("Rental", "Customer"); } }
        [JsonIgnore]
        public Staff Staff { get { return this.entity.NavigateSingle<Staff>("Rental", "Staff"); } }
        
    }

    public sealed class Staff : IDerivedEntity
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
        public IEnumerable<Payment> Payments { get { return this.entity.NavigateMulti<Payment>("Staff", "Payments"); } }
        [JsonIgnore]
        public IEnumerable<Rental> Rentals { get { return this.entity.NavigateMulti<Rental>("Staff", "Rentals"); } }
        [JsonIgnore]
        public Address Address { get { return this.entity.NavigateSingle<Address>("Staff", "Address"); } }
        [JsonIgnore]
        public Store Store { get { return this.entity.NavigateSingle<Store>("Staff", "Store"); } }
        [JsonIgnore]
        public IEnumerable<Store> Stores { get { return this.entity.NavigateMulti<Store>("Staff", "Stores"); } }
        
    }

    public sealed class Store : IDerivedEntity
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
        public IEnumerable<Customer> Customers { get { return this.entity.NavigateMulti<Customer>("Store", "Customers"); } }
        [JsonIgnore]
        public IEnumerable<Inventory> Inventories { get { return this.entity.NavigateMulti<Inventory>("Store", "Inventories"); } }
        [JsonIgnore]
        public IEnumerable<Staff> Staffs { get { return this.entity.NavigateMulti<Staff>("Store", "Staffs"); } }
        [JsonIgnore]
        public Staff Staff { get { return this.entity.NavigateSingle<Staff>("Store", "Staff"); } }
        [JsonIgnore]
        public Address Address { get { return this.entity.NavigateSingle<Address>("Store", "Address"); } }
        
    }

}

#pragma warning restore SA1649, SA1128, SA1005, SA1516, SA1402, SA1028, SA1119, SA1507, SA1502, SA1508, SA1122, SA1633, SA1300
