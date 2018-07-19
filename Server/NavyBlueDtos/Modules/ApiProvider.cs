using System;
using System.Collections.Generic;
using System.Linq;

namespace NavyBlueDtos
{
    public static class ApiProvider
    {

        public static ResultSerialResponse HandleGet(string entitySetName, QueryParams queryParams, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            var resultSerialResponse = ResultSerialUtils.FetchResponseData(entityTypeName, queryObject, "crud", dataServiceDto);
            return resultSerialResponse;
        }

        public static ResultSingleSerialData HandleGetSingle(string entitySetName, QueryParams queryParams, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (queryObject.Keys == null || queryObject.Keys.Count() != 1 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSingleSerialData = dataServiceDto.DataViewDto.GetSingleItem(entityTypeName, queryObject.Keys.FirstOrDefault(), queryObject.Expand);
            return resultSingleSerialData;
        }

        public static ResultSerialData HandleGetMany(string entitySetName, QueryParams queryParams, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (queryObject.Keys == null || queryObject.Keys.Count() == 0 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSerialData = dataServiceDto.DataViewDto.GetMultipleItems(entityTypeName, queryObject.Keys, queryObject.Expand);
            return resultSerialData;
        }

        public static ResultSingleSerialData HandleInsertEntity(string entitySetName, Dto dto, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (!ApiProviderUtils.ValidDtoKey(entityTypeName, dto, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSingleSerialData = dataServiceDto.DataViewDto.InsertItem(entityTypeName, dto);
            return resultSingleSerialData;
        }

        public static List<ResultSingleSerialData> HandleInsertEntityBatch(string entitySetName, IEnumerable<Dto> dtos, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (!ApiProviderUtils.ValidKeys(entityTypeName, dtos, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSingleSerialDataList = dataServiceDto.DataViewDto.InsertItems(entityTypeName, dtos);
            return resultSingleSerialDataList;
        }

        public static ResultSingleSerialData HandleUpdateEntity(string entitySetName, QueryParams queryParams, Dto dto, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (queryObject.Keys == null || queryObject.Keys.Count() != 1 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            if (!ApiProviderUtils.ValidDto(entityTypeName, queryObject.Keys.FirstOrDefault(), dto, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSingleSerialData = dataServiceDto.DataViewDto.UpdateItem(entityTypeName, DalUtils.Extend(dto, queryObject.Keys.FirstOrDefault()));
            return resultSingleSerialData;
        }

        public static List<ResultSingleSerialData> HandleUpdateEntityBatch(string entitySetName, IEnumerable<Dto> dtos, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (!ApiProviderUtils.ValidKeys(entityTypeName, dtos, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSingleSerialDataList = dataServiceDto.DataViewDto.UpdateItems(entityTypeName, dtos);
            return resultSingleSerialDataList;
        }

        public static ResultSingleSerialData HandleDeleteEntity(string entitySetName, QueryParams queryParams, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (queryObject.Keys == null || queryObject.Keys.Count() != 1 || !ApiProviderUtils.ValidDtoKey(entityTypeName, queryObject.Keys.FirstOrDefault(), dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSingleSerialData = dataServiceDto.DataViewDto.DeleteItem(entityTypeName, queryObject.Keys.FirstOrDefault());
            return resultSingleSerialData;
        }

        //// in aceasta varianta informatiile de stergere sunt trimise in body ca dtos[]
        //public static ResultSerialData HandleDeleteEntityBatch1(string entitySetName,  dtos, DataServiceDto dataServiceDto)
        //{
        //    entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.Metadata);
        //    var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.Metadata);
        //    if (!ApiProviderUtils.ValidKeys(entityTypeName, dtos, dataServiceDto.Metadata))
        //    {
        //        throw new DtosException(code: 400, message: "Bad Request");
        //    }
        //    var resultSerialData = dataServiceDto.DataViewDto.DeleteItems(entityTypeName, dtos);
        //    return resultSerialData;
        //}

        // in aceasta varianta informatiile de stergere sunt trimise in query string
        // similar cu handleGetMany
        public static ResultSerialData HandleDeleteEntityBatch(string entitySetName, QueryParams queryParams, DataServiceDto dataServiceDto)
        {
            entitySetName = ApiProviderUtils.FixEntitySetNameCase(entitySetName, dataServiceDto.MetadataSrv);
            var queryObject = QueryUtils.RenderQueryObject(queryParams);
            var entityTypeName = ApiProviderUtils.GetEntityTypeName(entitySetName, dataServiceDto.MetadataSrv);
            if (queryObject.Keys == null || queryObject.Keys.Count() == 0 || !ApiProviderUtils.ValidKeys(entityTypeName, queryObject.Keys, dataServiceDto.MetadataSrv))
            {
                throw new DtosException(code: 400, message: "Bad Request");
            }
            var resultSerialData = dataServiceDto.DataViewDto.DeleteItems(entityTypeName, queryObject.Keys);
            return resultSerialData;
        }

    }

}