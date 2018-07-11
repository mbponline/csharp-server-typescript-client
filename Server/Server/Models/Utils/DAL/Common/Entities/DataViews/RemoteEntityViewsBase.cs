using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
	public class RemoteEntityViewsBase : Dictionary<string, object>
	{
		public RemoteEntityViewsBase(DataAdapter dataAdapter, DataContext dataContext)
		{
			this.dataAdapter = dataAdapter;
			this.dataContext = dataContext;
		}

		private readonly DataAdapter dataAdapter;
		private readonly DataContext dataContext;

		protected DataViewRemoteEntity<T> GetPropertyValue<T>(/*string entityTypeName*/)
			where T : class, IDerivedEntity
		{
			var entityTypeName = typeof(T).Name;
			DataViewRemoteEntity<T> instance;
			if (this.ContainsKey(entityTypeName))
			{
				instance = (DataViewRemoteEntity<T>)this[entityTypeName];
			}
			else
			{
				instance = new DataViewRemoteEntity<T>(entityTypeName, this.dataAdapter, this.dataContext);
				this[entityTypeName] = instance;
			}
			return instance;
		}
	}
}
