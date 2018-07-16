using System.Collections.Generic;

namespace Server.Models.Utils.DAL.Common
{
    public class LocalDtoViewsBase : Dictionary<string, object>
    {
        public LocalDtoViewsBase(DataContext dataContext, MetadataSrv.Metadata metadataSrv)
        {
            this.dataContext = dataContext;
            this.metadataSrv = metadataSrv;
        }

        private readonly DataContext dataContext;
        private readonly MetadataSrv.Metadata metadataSrv;

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
                instance = new DataViewLocalDto<T>(entityTypeName, this.dataContext, this.metadataSrv);
                this[entityTypeName] = instance;
            }
            return instance;
        }
    }

}
