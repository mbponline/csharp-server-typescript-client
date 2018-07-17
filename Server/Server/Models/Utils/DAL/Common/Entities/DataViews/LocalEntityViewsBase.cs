using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
	public class LocalEntityViewsBase : Dictionary<string, object>
	{
		private readonly DataContext dataContext;

		public LocalEntityViewsBase(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		protected DataViewLocalEntity GetPropertyValue(string entityTypeName)
		{
			DataViewLocalEntity instance;
			if (this.ContainsKey(entityTypeName))
			{
				instance = (DataViewLocalEntity)this[entityTypeName];
			}
			else
			{
				instance = new DataViewLocalEntity(entityTypeName, this.dataContext);
				this[entityTypeName] = instance;
			}
			return instance;
		}
	}
}
