using NavyBlueDtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavyBlueEntities
{
    public class DataViewLocalEntity
    {
        private readonly string entityTypeName;
        private readonly DataContext dataContext;

        public DataViewLocalEntity(string entityTypeName, DataContext dataContext)
        {
            this.entityTypeName = entityTypeName;
            this.dataContext = dataContext;
        }

        public IEnumerable<Entity> GetItems(Func<Entity, bool> predicate)
        {
            var entities = Enumerable.Empty<Entity>();
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                entities = entitySet.Filter(predicate);
            }
            return entities;
        }

        public IEnumerable<Entity> GetMultipleItems(IEnumerable<Dto> partialDtos)
        {
            var entities = new List<Entity>();
            var entity = default(Entity);
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                foreach (var partialDto in partialDtos)
                {
                    entity = entitySet.FindByKey(partialDto);
                    if (entity != null)
                    {
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }

        public Entity GetSingleItem(Func<Entity, bool> predicate)
        {
            var entity = default(Entity);
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                entity = entitySet.Find(predicate);
            }
            return entity;
        }

        public Entity GetSingleItem(Dto partialDto)
        {
            var entity = default(Entity);
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                entity = entitySet.FindByKey(partialDto /*partialEntity*/);
            }
            return entity;
        }

        public Entity CreateItemDetached()
        {
            var entity = this.dataContext.CreateItemDetached(this.entityTypeName);
            return entity;
        }

        public void DetachItem(Entity entity)
        {
            var entitySet = this.dataContext.entitySets[this.entityTypeName];
            entitySet.DeleteEntity(entity);
        }

        public void DetachItems(IEnumerable<Entity> entities)
        {
            var entitySet = this.dataContext.entitySets[this.entityTypeName];
            foreach (var entity in entities)
            {
                entitySet.DeleteEntity(entity);
            }
        }

        public void DetachAll()
        {
            var entitySet = this.dataContext.entitySets[this.entityTypeName];
            entitySet.DeleteAll();
        }
    }

}