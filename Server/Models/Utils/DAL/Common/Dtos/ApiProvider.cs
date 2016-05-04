using System.Collections.Generic;
using System.Web;

namespace Server.Models.Utils.DAL.Common
{
    public static partial class ApiProvider
    {

        public static ResultSerialResponse HandleGet(string entitySetName, QueryParams queryParams, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            var result = ResultSerialUtils.FetchResponseData(entityTypeName, queryObject, "crud", dataService);
            return result;
        }

        public static ResultSingleSerialData HandleGetSingle(string entitySetName, QueryParams queryParams, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (queryObject.Keys == null || queryObject.Keys.Length != 1 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.GetSingleItem(entityTypeName, queryObject.Keys[0], queryObject.Expand);
            return result;
        }

        public static ResultSerialData HandleGetMany(string entitySetName, QueryParams queryParams, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (queryObject.Keys == null || queryObject.Keys.Length == 0 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.GetMultipleItems(entityTypeName, queryObject.Keys, queryObject.Expand);
            return result;
        }

        public static ResultSingleSerialData HandleUpdateEntity(string entitySetName, QueryParams queryParams, Dto dto, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (queryObject.Keys == null || queryObject.Keys.Length != 1 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            if (!ApiProviderUtils.ValidDto(entityTypeName, queryObject.Keys[0], dto, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.UpdateItem(entityTypeName, DalUtils.Extend(dto, queryObject.Keys[0]));
            return result;
        }

        public static List<ResultSingleSerialData> HandleUpdateEntityBatch(string entitySetName, Dto[] dtos, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (!ApiProviderUtils.ValidKeys(entityTypeName, dtos, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.UpdateItems(entityTypeName, dtos);
            return result;
        }

        public static ResultSingleSerialData HandleInsertEntity(string entitySetName, Dto dto, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (!ApiProviderUtils.ValidDtoKey(entityTypeName, dto, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.InsertItem(entityTypeName, dto);
            return result;
        }

        public static List<ResultSingleSerialData> HandleInsertEntityBatch(string entitySetName, Dto[] dtos, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (!ApiProviderUtils.ValidKeys(entityTypeName, dtos, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.InsertItems(entityTypeName, dtos);
            return result;
        }

        public static ResultSingleSerialData HandleDeleteEntity(string entitySetName, QueryParams queryParams, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (queryObject.Keys == null || queryObject.Keys.Length != 1 || !ApiProviderUtils.ValidDtoKey(entityTypeName, queryObject.Keys[0], dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.DeleteItem(entityTypeName, queryObject.Keys[0]);
            return result;
        }

        //// in aceasta varianta informatiile de stergere sunt trimise in body ca dtos[]
        //public static ResultSerialData HandleDeleteEntityBatch1(string entitySetName, Dto[] dtos, DataServiceDto dataService)
        //{
        //    entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
        //    var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
        //    if (!ApiProviderUtils.ValidKeys(entityTypeName, dtos, dataService.Metadata))
        //    {
        //        throw new HttpException(httpCode: 400, message: "Bad Request");
        //    }
        //    var result = dataService.DataViewDto.DeleteItems(entityTypeName, dtos);
        //    return result;
        //}

        // in aceasta varianta informatiile de stergere sunt trimise in query string
        // similar cu handleGetMany
        public static ResultSerialData HandleDeleteEntityBatch(string entitySetName, QueryParams queryParams, DataServiceDto dataService)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataService.Metadata);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataService.Metadata);
            if (queryObject.Keys == null || queryObject.Keys.Length == 0 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataService.Metadata))
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            var result = dataService.DataViewDto.DeleteItems(entityTypeName, queryObject.Keys);
            return result;
        }

    }

}