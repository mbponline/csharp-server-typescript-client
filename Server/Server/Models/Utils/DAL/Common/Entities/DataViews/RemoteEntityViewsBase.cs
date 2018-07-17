using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
    public class RemoteEntityViewsBase : Dictionary<string, object>
    {
        private readonly DataViewDto dataViewDto;
        private readonly DataContext dataContext;

        public RemoteEntityViewsBase(DataViewDto dataViewDto, DataContext dataContext)
        {
            this.dataViewDto = dataViewDto;
            this.dataContext = dataContext;
        }

        protected DataViewRemoteEntity GetPropertyValue(string entityTypeName)
        {
            DataViewRemoteEntity instance;
            if (this.ContainsKey(entityTypeName))
            {
                instance = (DataViewRemoteEntity)this[entityTypeName];
            }
            else
            {
                instance = new DataViewRemoteEntity(entityTypeName, this.dataViewDto, this.dataContext);
                this[entityTypeName] = instance;
            }
            return instance;
        }
    }
}
