using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models.Utils.DAL.Common
{
    public class DataAdapter
    {
        public DataAdapter(Metadata metadata, string connectionString)
        {
            this.metadata = metadata;
            this.dialect = metadata.Dialect();
            this.connectionString = connectionString;
        }

        private readonly Metadata metadata;
        private readonly Dialect dialect;
        private readonly string connectionString;

        /**
         * Count entity collection
         */
        public int Count(string entityTypeName, QueryObject queryObject)
        {
            var queryObjectLocal = new QueryObject()
            {
                Filter = queryObject.Filter,
                FilterExpand = queryObject.FilterExpand,
                CustomQueryTable = queryObject.CustomQueryTable
            };
            return ReadUtils.Count(entityTypeName, queryObjectLocal, this.metadata, this.dialect, this.connectionString);
        }

        /**
         * Query entity collection
         */
        public ResultSerialData QueryAll(string entityTypeName, QueryObject queryObject)
        {
            return ReadUtils.Fetch(entityTypeName, queryObject, this.metadata, this.dialect, this.connectionString);
        }

        /**
         * Retrive a single entity
         */
        public ResultSingleSerialData LoadOne(string entityTypeName, Dto dto, string[] expand)
        {
            var result = ReadUtils.FetchOne(entityTypeName, dto, expand, this.metadata, this.dialect, this.connectionString);
            if (result.Items.Count() > 0)
            {
                return result.ToSingle();
            }
            else
            {
                throw new HttpException(httpCode: 404, message: "Not Found");
            }
        }

        /**
         * Retrive multiple entities
         */
        public ResultSerialData LoadMany(string entityTypeName, Dto[] dtos, string[] expand)
        {
            return ReadUtils.FetchMany(entityTypeName, dtos, expand, this.metadata, this.dialect, this.connectionString);
        }

        /**
         * Insert single entity
         */
        public ResultSingleSerialData PostItem(string entityTypeName, Dto dto)
        {
            var dataOriginal = ReadUtils.FetchOne(entityTypeName, dto, null, this.metadata, this.dialect, this.connectionString);
            if (dataOriginal.Items.Count() > 0)
            {
                throw new HttpException(httpCode: 409, message: "Conflict");
            }
            else
            {
                var result = CudUtils.InsertEntity(entityTypeName, dto, this.metadata, this.dialect, this.connectionString);
                return result.ToSingle();
            }
        }

        /**
        * Insert multiple entities
        */
        public List<ResultSingleSerialData> PostItems(string entityTypeName, Dto[] dtos)
        {
            var dataOriginal = ReadUtils.FetchMany(entityTypeName, dtos, null, this.metadata, this.dialect, this.connectionString);
            if (dataOriginal.Items.Count() > 0)
            {
                throw new HttpException(httpCode: 409, message: "Conflict");
            }
            else
            {
                var entityInserts = new List<ResultSingleSerialData>();
                foreach (var dto in dtos)
                {
                    var entity = CudUtils.InsertEntity(entityTypeName, dto, this.metadata, this.dialect, this.connectionString);
                    entityInserts.Add(entity.ToSingle());
                }
                return entityInserts;
            }
        }

        /**
         * Update single entity
         */
        public ResultSingleSerialData PutItem(string entityTypeName, Dto dto)
        {
            var dataOriginal = ReadUtils.FetchOne(entityTypeName, dto, null, this.metadata, this.dialect, this.connectionString);
            if (dataOriginal.Items.Count() == 0)
            {
                throw new HttpException(httpCode: 404, message: "Not Found");
            }
            else
            {
                const bool returnUpdated = false;
                var result = CudUtils.UpdateEntity(entityTypeName, JObject.FromObject(dataOriginal.Items.FirstOrDefault()), dto, this.metadata, this.dialect, this.connectionString, returnUpdated);
                if (returnUpdated)
                {
                    if (result.Items.Count() > 0)
                    {
                        return result.ToSingle();
                    }
                    else
                    {
                        throw new HttpException(httpCode: 304, message: "Not Modified");
                    }
                }
                else
                {
                    throw new HttpException(httpCode: 204, message: "No Content");
                }
            }
        }

        /**
         * Update multiple entities
         */
        public List<ResultSingleSerialData> PutItems(string entityTypeName, Dto[] dtos)
        {
            var dataOriginal = ReadUtils.FetchMany(entityTypeName, dtos, null, this.metadata, this.dialect, this.connectionString);
            if (dataOriginal.Items.Count() == 0)
            {
                throw new HttpException(httpCode: 404, message: "Not Found");
            }
            else if (dataOriginal.Items.Count() != dtos.Length)
            {
                throw new HttpException(httpCode: 400, message: "Bad Request");
            }
            else
            {
                var keyNames = this.metadata.EntityTypes[entityTypeName].Key;
                var entityUpdates = DalUtils.LeftJoin(dataOriginal.Items, dtos,
                    (ent, dto) => CudUtils.CompareByKey(JObject.FromObject(ent).ToObject<Dto>(), dto, keyNames),
                    (ent, dto) => CudUtils.UpdateEntity(entityTypeName, JObject.FromObject(ent), dto, this.metadata, this.dialect, this.connectionString)
                );
                var updated = new List<ResultSingleSerialData>();
                foreach (var next in entityUpdates)
                {
                    if (next.Items.Count() > 0)
                    {
                        updated.Add(next.ToSingle());
                    }
                }

                if (updated.Count > 0)
                {
                    return updated;
                }
                else
                {
                    var total = 0;
                    foreach (var next in entityUpdates)
                    {
                        total += next.Items.Count();
                    }
                    if (total > 0)
                    {
                        throw new HttpException(httpCode: 204, message: "No Content");
                    }
                    else
                    {
                        throw new HttpException(httpCode: 304, message: "Not Modified");
                    }
                }
            }
        }

        /**
         * Delete single entity
         */
        public ResultSingleSerialData DeleteItem(string entityTypeName, Dto dto)
        {
            var dataOriginal = ReadUtils.FetchOne(entityTypeName, dto, null, this.metadata, this.dialect, this.connectionString);
            if (dataOriginal.Items.Count() == 0)
            {
                throw new HttpException(httpCode: 404, message: "Not Found");
            }
            else
            {
                CudUtils.DeleteEntity(entityTypeName, dto, this.metadata, this.dialect, this.connectionString);
                return dataOriginal.ToSingle();
            }
        }

        /**
         * Delete multiple entities
         */
        public ResultSerialData DeleteItems(string entityTypeName, Dto[] dtos)
        {
            var dataOriginal = ReadUtils.FetchMany(entityTypeName, dtos, null, this.metadata, this.dialect, this.connectionString);
            if (dataOriginal.Items.Count() == 0)
            {
                throw new HttpException(httpCode: 404, message: "Not Found");
            }
            else
            {
                foreach (var dto in dtos)
                {
                    CudUtils.DeleteEntity(entityTypeName, dto, this.metadata, this.dialect, this.connectionString);
                }
                return dataOriginal;
            }
        }
    }

}