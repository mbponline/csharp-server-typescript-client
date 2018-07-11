using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{

    public class DataViewDto
    {
        public DataViewDto(DataAdapter dataAdapter)
        {
            this.dataAdapter = dataAdapter;
        }

        private readonly DataAdapter dataAdapter;

        public int Count(string entityTypeName, QueryObject queryObject)
        {
            return this.dataAdapter.Count(entityTypeName, queryObject);
        }

        public ResultSerialData GetItems(string entityTypeName, QueryObject queryObject)
        {
            return this.dataAdapter.QueryAll(entityTypeName, queryObject);
        }

		public ResultSingleSerialData GetSingleItem(string entityTypeName, Dto partialDto, string[] expand = null)
        {
            return this.dataAdapter.LoadOne(entityTypeName, partialDto, expand);
        }

		public ResultSerialData GetMultipleItems(string entityTypeName, IEnumerable<Dto> partialDtos, string[] expand = null)
        {
            return this.dataAdapter.LoadMany(entityTypeName, partialDtos, expand);
        }

        public ResultSingleSerialData InsertItem(string entityTypeName, Dto entity)
        {
            return this.dataAdapter.PostItem(entityTypeName, entity);
        }

		public List<ResultSingleSerialData> InsertItems(string entityTypeName, IEnumerable<Dto> dtos)
        {
            return this.dataAdapter.PostItems(entityTypeName, dtos);
        }

		public ResultSingleSerialData UpdateItem(string entityTypeName, Dto partialDto)
        {
            return this.dataAdapter.PutItem(entityTypeName, partialDto);
        }

		public List<ResultSingleSerialData> UpdateItems(string entityTypeName, IEnumerable<Dto> partialDtos)
        {
            return this.dataAdapter.PutItems(entityTypeName, partialDtos);
        }

		public ResultSingleSerialData DeleteItem(string entityTypeName, Dto partialDto)
        {
            return this.dataAdapter.DeleteItem(entityTypeName, partialDto);
        }

		public ResultSerialData DeleteItems(string entityTypeName, IEnumerable<Dto> partialDtos)
        {
            return this.dataAdapter.DeleteItems(entityTypeName, partialDtos);
        }
    }

}