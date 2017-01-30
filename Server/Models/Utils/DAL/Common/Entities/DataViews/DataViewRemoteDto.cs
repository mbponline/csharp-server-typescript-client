using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{

	public class DataViewRemoteDto : DataViewDto
	{
		public DataViewRemoteDto(string entityTypeName, DataAdapter dataAdapter)
			: base(dataAdapter)
		{
			this.entityTypeName = entityTypeName;
		}

		private readonly string entityTypeName;

		public int Count(QueryObject queryObject)
		{
			return base.Count(this.entityTypeName, queryObject);
		}

		public ResultSerialData GetItems(QueryObject queryObject)
		{
			return base.GetItems(this.entityTypeName, queryObject);
		}

		public ResultSingleSerialData GetSingleItem(Dto partialDto, string[] expand = null)
		{
			return this.GetSingleItem(this.entityTypeName, partialDto, expand);
		}

		public ResultSerialData GetMultipleItems(IEnumerable<Dto> partialDtos, string[] expand = null)
		{
			return this.GetMultipleItems(this.entityTypeName, partialDtos, expand);
		}

		public ResultSingleSerialData InsertItem(Dto dto)
		{
			return this.InsertItem(this.entityTypeName, dto);
		}

		public List<ResultSingleSerialData> InsertItems(IEnumerable<Dto> dtos)
		{
			return this.InsertItems(this.entityTypeName, dtos);
		}

		public ResultSingleSerialData UpdateItem(Dto partialDto)
		{
			return this.UpdateItem(this.entityTypeName, partialDto);
		}

		public List<ResultSingleSerialData> UpdateItems(IEnumerable<Dto> partialDtos)
		{
			return this.UpdateItems(this.entityTypeName, partialDtos);
		}

		public ResultSingleSerialData DeleteItem(Dto partialDto)
		{
			return this.DeleteItem(this.entityTypeName, partialDto);
		}

		public ResultSerialData DeleteItems(IEnumerable<Dto> partialDtos)
		{
			return this.DeleteItems(this.entityTypeName, partialDtos);
		}
	}

}