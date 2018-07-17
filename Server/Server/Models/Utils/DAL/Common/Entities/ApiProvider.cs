using System.Collections.Generic;
using System.Web;

namespace Server.Models.Utils.DAL.Common
{
    public static partial class ApiProvider
    {

        public static ResultSerialResponse HandleGet<T>(QueryParams queryParams, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var result = ApiProvider.HandleGet(entityTypeName, queryParams, dataServiceDto);
            return result;
        }

        public static ResultSingleSerialData HandleGetSingle<T>(QueryParams queryParams, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSingleSerialData = ApiProvider.HandleGetSingle(entityTypeName, queryParams, dataServiceDto);
            return resultSingleSerialData;
        }

        public static ResultSerialData HandleGetMany<T>(QueryParams queryParams, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSerialData = ApiProvider.HandleGetMany(entityTypeName, queryParams, dataServiceDto);
            return resultSerialData;
        }

        public static ResultSingleSerialData HandleInsertEntity<T>(Dto dto, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSingleSerialData = ApiProvider.HandleInsertEntity(entityTypeName, dto, dataServiceDto);
            return resultSingleSerialData;
        }

        public static List<ResultSingleSerialData> HandleInsertEntityBatch<T>(IEnumerable<Dto> dtos, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSingleSerialDataList = ApiProvider.HandleInsertEntityBatch(entityTypeName, dtos, dataServiceDto);
            return resultSingleSerialDataList;
        }

        public static ResultSingleSerialData HandleUpdateEntity<T>(QueryParams queryParams, Dto dto, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSingleSerialData = ApiProvider.HandleUpdateEntity(entityTypeName, queryParams, dto, dataServiceDto);
            return resultSingleSerialData;
        }

        public static List<ResultSingleSerialData> HandleUpdateEntityBatch<T>(IEnumerable<Dto> dtos, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSingleSerialDataList = ApiProvider.HandleUpdateEntityBatch(entityTypeName, dtos, dataServiceDto);
            return resultSingleSerialDataList;
        }

        public static ResultSingleSerialData HandleDeleteEntity<T>(QueryParams queryParams, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSingleSerialData = ApiProvider.HandleDeleteEntity(entityTypeName, queryParams, dataServiceDto);
            return resultSingleSerialData;
        }

        //// in aceasta varianta informatiile de stergere sunt trimise in body ca dtos[]
        //public static ResultSerialData<T> HandleDeleteEntityBatch1<T>(IEnumerable<Dto> dtos, DataServiceDto dataServiceDto)
        //    where T : class
        //{
        //    var entityTypeName = typeof(T).Name;
        //    var resultSerialData = ApiProvider.HandleDeleteEntityBatch1(entityTypeName, dtos, dataServiceDto);
        //    return resultSerialData;
        //}

        // in aceasta varianta informatiile de stergere sunt trimise in query string
        // similar cu handleGetMany
        public static ResultSerialData HandleDeleteEntityBatch<T>(QueryParams queryParams, DataServiceDto dataServiceDto)
            where T : class
        {
            var entityTypeName = typeof(T).Name;
            var resultSerialData = ApiProvider.HandleDeleteEntityBatch(entityTypeName, queryParams, dataServiceDto);
            return resultSerialData;
        }

    }

}