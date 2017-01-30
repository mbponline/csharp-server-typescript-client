using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
	public class LocalEntityViewsBase : Dictionary<string, object>
	{
		public LocalEntityViewsBase(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		private readonly DataContext dataContext;

		protected DataViewLocalEntity<T> GetPropertyValue<T>(/*string entityTypeName*/)
			where T : class, IDerivedEntity
		{
			var entityTypeName = typeof(T).Name;
			DataViewLocalEntity<T> instance;
			if (this.ContainsKey(entityTypeName))
			{
				instance = (DataViewLocalEntity<T>)this[entityTypeName];
			}
			else
			{
				instance = new DataViewLocalEntity<T>(entityTypeName, this.dataContext);
				this[entityTypeName] = instance;
			}
			return instance;
		}
	}
}
