using System.Collections.Generic;
using System.Linq;

namespace Server.Models.Utils.DAL.Common
{

	public class DataViewRemoteEntity<T> : DataViewDto
		where T : class, IDerivedEntity
	{
		public DataViewRemoteEntity(string entityTypeName, DataAdapter dataAdapter, DataContext dataContext)
			: base(dataAdapter)
		{
			this.entityTypeName = entityTypeName;
			this.dataContext = dataContext;
		}

		private readonly string entityTypeName;
		private readonly DataContext dataContext;

		public int Count(QueryObject queryObject)
		{
			return this.Count(this.entityTypeName, queryObject);
		}

		public IEnumerable<T> GetItems(QueryObject queryObject)
		{
			var resultSerialData = base.GetItems(this.entityTypeName, queryObject);
			var derivedEntityList = this.dataContext.AttachEntities(resultSerialData); // as List<T>;
			return derivedEntityList.Cast<T>().ToList();
		}

		public T GetSingleItem(Dto partialDto, string[] expand = null)
		{
			var resultSingleSerialData = base.GetSingleItem(this.entityTypeName, partialDto, expand);
			var derivedEntity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
			return (T)derivedEntity;
		}

		public IEnumerable<T> GetMultipleItems(IEnumerable<Dto> partialDtos, string[] expand = null)
		{
			var resultSerialData = base.GetMultipleItems(this.entityTypeName, partialDtos, expand);
			var derivedEntityList = this.dataContext.AttachEntities(resultSerialData); // as List<T>;
			return derivedEntityList.Cast<T>().ToList();
		}

		public T InsertItem(Dto dto)
		{
			var resultSingleSerialData = base.InsertItem(this.entityTypeName, dto);
			var derivedEntity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
			return (T)derivedEntity;
		}

		public IEnumerable<T> InsertItems(IEnumerable<Dto> dtos)
		{
			var derivedEntityList = new List<T>();
			var resultSingleSerialDataList = base.InsertItems(this.entityTypeName, dtos);
			foreach (var resultSingleSerialData in resultSingleSerialDataList)
			{
				var derivedEntity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
				derivedEntityList.Add((T)derivedEntity);
			}
			return derivedEntityList;
		}

		public T UpdateItem(Dto partialDto)
		{
			var resultSingleSerialData = base.UpdateItem(this.entityTypeName, partialDto);
			var derivedEntity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
			return (T)derivedEntity;
		}

		public IEnumerable<T> UpdateItems(IEnumerable<Dto> partialDtos)
		{
			var derivedEntityList = new List<T>();
			var resultSingleSerialDataList = base.UpdateItems(this.entityTypeName, partialDtos);
			foreach (var resultSingleSerialData in resultSingleSerialDataList)
			{
				var derivedEntity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
				derivedEntityList.Add((T)derivedEntity);
			}
			return derivedEntityList;
		}

		public T DeleteItem(Dto partialDto)
		{
			var resultSingleSerialData = base.DeleteItem(this.entityTypeName, partialDto);
			var derivedEntity = default(T);
			if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
			{
				var entitySet = (EntitySet<T>)this.dataContext.entitySets[this.entityTypeName];
				derivedEntity = entitySet.FindByKey(partialDto);
				if (derivedEntity != null)
				{
					entitySet.DeleteEntity(derivedEntity);
				}
			}
			return derivedEntity;
		}

		public IEnumerable<T> DeleteItems(IEnumerable<Dto> partialDtos)
		{
			var resultSerialData = base.DeleteItems(this.entityTypeName, partialDtos);
			var derivedEntityList = new List<T>();
			var derivedEntity = default(T);
			if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
			{
				var entitySet = (EntitySet<T>)this.dataContext.entitySets[this.entityTypeName];
				foreach (var partialDto in partialDtos)
				{
					derivedEntity = entitySet.FindByKey(partialDto);
					if (derivedEntity != null)
					{
						derivedEntityList.Add(derivedEntity);
						entitySet.DeleteEntity(derivedEntity);
					}
				}
			}
			return derivedEntityList;
		}
	}

}