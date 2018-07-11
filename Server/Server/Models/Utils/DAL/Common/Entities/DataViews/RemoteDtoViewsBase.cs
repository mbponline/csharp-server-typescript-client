using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
	public class RemoteDtoViewsBase : Dictionary<string, DataViewRemoteDto>
	{
		public RemoteDtoViewsBase(DataAdapter dataAdapter)
		{
			this.dataAdapter = dataAdapter;
		}

		private readonly DataAdapter dataAdapter;

		protected DataViewRemoteDto GetPropertyValue(string entityTypeName)
		{
			DataViewRemoteDto instance;
			if (this.ContainsKey(entityTypeName))
			{
				instance = this[entityTypeName];
			}
			else
			{
				instance = new DataViewRemoteDto(entityTypeName, this.dataAdapter);
				this[entityTypeName] = instance;
			}
			return instance;
		}
	}
}
