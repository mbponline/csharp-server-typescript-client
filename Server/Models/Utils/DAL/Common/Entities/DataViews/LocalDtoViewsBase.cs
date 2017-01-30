
using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
	public class LocalDtoViewsBase : Dictionary<string, object>
	{
		public LocalDtoViewsBase(DataContext dataContext, Metadata metadata)
		{
			this.dataContext = dataContext;
			this.metadata = metadata;
		}

		private readonly DataContext dataContext;
		private readonly Metadata metadata;

		protected DataViewLocalDto<T> GetPropertyValue<T>(/*string entityTypeName*/)
			where T : class, IDerivedEntity
		{
			var entityTypeName = typeof(T).Name;
			DataViewLocalDto<T> instance;
			if (this.ContainsKey(entityTypeName))
			{
				instance = (DataViewLocalDto<T>)this[entityTypeName];
			}
			else
			{
				instance = new DataViewLocalDto<T>(entityTypeName, this.dataContext, this.metadata);
				this[entityTypeName] = instance;
			}
			return instance;
		}
	}

}
