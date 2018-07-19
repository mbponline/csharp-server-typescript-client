using NavyBlueDtos;
using System.Collections.Generic;
using System.Linq;
using MetadataSrv = NavyBlueDtos.MetadataSrv;

namespace NavyBlueEntities
{
    public class DataContext
    {
        private MetadataSrv.Metadata metadataSrv;
        public Dictionary<string, EntitySet> entitySets;

        public DataContext(MetadataSrv.Metadata metadataSrv)
        {
            this.metadataSrv = metadataSrv;
            this.entitySets = new Dictionary<string, EntitySet>();
        }

        public Dictionary<string, List<Entity>> GetEntitySets()
        {
            var result = new Dictionary<string, List<Entity>>();
            foreach (var entitySet in this.entitySets)
            {
                var entitySetValue = entitySet.Value;
                result.Add(entitySet.Key, entitySetValue.Items); //.Cast<Entity>().ToList()
            }
            return result;
        }

        public IEnumerable<Entity> GetRelatedEntities(string entityTypeName, IEnumerable<Dto> dtos, string navigationPropertyName)
        {
            var navElement = this.metadataSrv.EntityTypes[entityTypeName].NavigationProperties[navigationPropertyName];
            var remoteEntitySet = this.entitySets.ContainsKey(navElement.EntityTypeName) ? this.entitySets[navElement.EntityTypeName] : null;
            return remoteEntitySet != null ? remoteEntitySet.NavigateAllRelated(dtos, navElement.KeyLocal, navElement.KeyRemote) : Enumerable.Empty<Entity>(); //.Cast<Entity>().ToList()
        }

        public Entity CreateItemDetached(string entityTypeName)
        {
            //if (!this.entitySets.ContainsKey(entityTypeName))
            //{
            //    this.InitializeDataSet(entityTypeName);
            //}
            //var entityType = Type.GetType(this.metadataSrv.Namespace + "." + entityTypeName);
            //var entity = Activator.CreateInstance(entityType);

            var entityType = this.metadataSrv.EntityTypes[entityTypeName];
            var dto = new Dto();
            dto.SetDefaultValues(entityType);
            var entity = new Entity(entityTypeName, dto);
            return entity;
        }

        public void Clear()
        {
            foreach (var entitySet in this.entitySets)
            {
                var entitySetValue = entitySet.Value;
                entitySetValue.DeleteAll();
            }
        }

        public void Dispose()
        {
            // se va apela inainte de incetarea utilizarii obiectului
            // pentru a evita aparitia de memory leaks si a usura activitatea GC-ului
            foreach (var entitySet in this.entitySets)
            {
                var entitySetValue = entitySet.Value;
                entitySetValue.Dispose();
            }
            this.entitySets = null;
            this.metadataSrv = null;
        }

        public IEnumerable<Entity> AttachEntities(ResultSerialData resultSerialData)
        {
            var entityTypeName = resultSerialData.EntityTypeName;
            var entities = this.TraverseResults(entityTypeName, resultSerialData.Items);
            this.AttachRelatedItems(resultSerialData.RelatedItems);
            return entities;
        }

        public Entity AttachSingleEntitiy(ResultSingleSerialData resultSingleSerialData)
        {
            var entityTypeName = resultSingleSerialData.EntityTypeName;
            var entities = this.TraverseResults(entityTypeName, new List<Dto>() { resultSingleSerialData.Item });
            this.AttachRelatedItems(resultSingleSerialData.RelatedItems);
            return entities.FirstOrDefault();
        }

        private void AttachRelatedItems(Dictionary<string, IEnumerable<Dto>> relatedItems)
        {
            if (relatedItems != null)
            {
                foreach (var item in relatedItems)
                {
                    this.TraverseResults(item.Key, item.Value);
                }
            }
        }

        private IEnumerable<Entity> TraverseResults(string entityTypeName, IEnumerable<Dto> dtos)
        {
            if (!this.entitySets.ContainsKey(entityTypeName))
            {
                this.InitializeDataSet(entityTypeName);
            }
            var entities = this.ProcessEntitySet(entityTypeName, dtos);
            return entities;
        }


        private IEnumerable<Entity> ProcessEntitySet(string entityTypeName, IEnumerable<Dto> dtos)
        {
            var entities = new List<Entity>();
            foreach (var dto in dtos)
            {
                var entity = this.ProcessEntity(entityTypeName, dto);
                entities.Add(entity);
            }
            return entities;
        }

        private Entity ProcessEntity(string entityTypeName, Dto dto)
        {
            var entitySetValue = this.entitySets[entityTypeName];
            var entity = entitySetValue.UpdateEntity(dto);
            return entity;
        }

        private void InitializeDataSet(string entityTypeName)
        {
            // Initializeaza EntitySet-ul precizat la momentul utilizarii (Lazy)
            this.entitySets[entityTypeName] = new EntitySet(entityTypeName, this.entitySets, this.metadataSrv);
        }
    }
}
