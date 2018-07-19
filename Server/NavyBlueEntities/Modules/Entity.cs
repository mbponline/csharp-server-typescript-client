using NavyBlueDtos;
using System.Collections.Generic;
using System.Linq;
using MetadataSrv = NavyBlueDtos.MetadataSrv;

namespace NavyBlueEntities
{
    public sealed class Entity
    {
        private Dictionary<string, EntitySet> entitySets;
        private MetadataSrv.Metadata metadataSrv;
        public string entityTypeName { get; private set; }
        public Dto dto { get; set; }

        public Entity(string entityTypeName, Dto dto)
        {
            this.entityTypeName = entityTypeName;
            this.dto = dto;
        }

        public void Attach(Dictionary<string, EntitySet> entitySets, MetadataSrv.Metadata metadataSrv)
        {
            this.entitySets = entitySets;
            this.metadataSrv = metadataSrv;
        }

        public void Detach()
        {
            this.entitySets = null;
            this.metadataSrv = null;
        }

        public Entity NavigateSingle(string entityTypeName, string navigationPropertyName)
        {
            var navElement = this.metadataSrv.EntityTypes[entityTypeName].NavigationProperties[navigationPropertyName];
            var remoteEntitySet = this.entitySets.ContainsKey(navElement.EntityTypeName) ? this.entitySets[navElement.EntityTypeName] : null;
            return remoteEntitySet != null ? remoteEntitySet.NavigateSingle(this, navElement.KeyLocal, navElement.KeyRemote) : null;
        }

        public IEnumerable<Entity> NavigateMulti(string entityTypeName, string navigationPropertyName)
        {
            var navElement = this.metadataSrv.EntityTypes[entityTypeName].NavigationProperties[navigationPropertyName];
            var remoteEntitySet = this.entitySets.ContainsKey(navElement.EntityTypeName) ? this.entitySets[navElement.EntityTypeName] : null;
            return remoteEntitySet != null ? remoteEntitySet.NavigateMulti(this, navElement.KeyLocal, navElement.KeyRemote) : Enumerable.Empty<Entity>();
        }
    }

}