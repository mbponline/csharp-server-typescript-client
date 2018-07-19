using System.Collections.Generic;
using MetadataSrv = NavyBlueDtos.MetadataSrv;

namespace NavyBlueEntities
{
    public class LocalDtoViewsBase : Dictionary<string, object>
    {
        private readonly DataContext dataContext;
        private readonly MetadataSrv.Metadata metadataSrv;

        public LocalDtoViewsBase(DataContext dataContext, MetadataSrv.Metadata metadataSrv)
        {
            this.dataContext = dataContext;
            this.metadataSrv = metadataSrv;
        }

        protected DataViewLocalDto GetPropertyValue(string entityTypeName)
        {
            DataViewLocalDto instance;
            if (this.ContainsKey(entityTypeName))
            {
                instance = (DataViewLocalDto)this[entityTypeName];
            }
            else
            {
                instance = new DataViewLocalDto(entityTypeName, this.dataContext, this.metadataSrv);
                this[entityTypeName] = instance;
            }
            return instance;
        }
    }

}
