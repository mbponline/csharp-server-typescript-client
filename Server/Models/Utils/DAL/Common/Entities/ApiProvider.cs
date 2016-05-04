using System.Collections.Generic;
using System.Web;

namespace Server.Models.Utils.DAL.Common
{
    public static partial class ApiProvider
    {

        public static ResultSerialResponse HandleGet<T>(QueryParams queryParams, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleGet(entityTypeName, queryParams, dataService);
            return result;
        }

        public static ResultSingleSerialData HandleGetSingle<T>(QueryParams queryParams, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleGetSingle(entityTypeName, queryParams, dataService);
            return result;
        }

        public static ResultSerialData HandleGetMany<T>(QueryParams queryParams, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleGetMany(entityTypeName, queryParams, dataService);
            return result;
        }

        public static ResultSingleSerialData HandleUpdateEntity<T>(QueryParams queryParams, Dto dto, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleUpdateEntity(entityTypeName, queryParams, dto, dataService);
            return result;
        }

        public static List<ResultSingleSerialData> HandleUpdateEntityBatch<T>(Dto[] dtos, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleUpdateEntityBatch(entityTypeName, dtos, dataService);
            return result;
        }

        public static ResultSingleSerialData HandleInsertEntity<T>(Dto dto, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleInsertEntity(entityTypeName, dto, dataService);
            return result;
        }

        public static List<ResultSingleSerialData> HandleInsertEntityBatch<T>(Dto[] dtos, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleInsertEntityBatch(entityTypeName, dtos, dataService);
            return result;
        }

        public static ResultSingleSerialData HandleDeleteEntity<T>(QueryParams queryParams, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleDeleteEntity(entityTypeName, queryParams, dataService);
            return result;
        }

        //// in aceasta varianta informatiile de stergere sunt trimise in body ca dtos[]
        //public static ResultSerialData<T> HandleDeleteEntityBatch1<T>(Dto[] dtos, DataServiceDto dataService)
        //    where T : class, IEntity
        //{
        //    var entityTypeName = typeof(T).Name;
        //    var result = ApiProvider.HandleDeleteEntityBatch1(entityTypeName, dtos, dataService);
        //    return result;
        //}

        // in aceasta varianta informatiile de stergere sunt trimise in query string
        // similar cu handleGetMany
        public static ResultSerialData HandleDeleteEntityBatch<T>(QueryParams queryParams, DataServiceDto dataService)
            where T : class, IEntity
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleDeleteEntityBatch(entityTypeName, queryParams, dataService);
            return result;
        }

    }

}