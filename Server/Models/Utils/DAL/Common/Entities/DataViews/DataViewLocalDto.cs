using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Models.Utils.DAL.Common
{
    public class DataViewLocalDto<T>
        where T : class, IEntity
    {
        public DataViewLocalDto(DataContext dataContext, Metadata metadata)
        {
            this.entityTypeName = typeof(T).Name;
            this.dataContext = dataContext;
            this.metadata = metadata;
        }

        private readonly string entityTypeName;
        private readonly DataContext dataContext;
        private readonly Metadata metadata;

        public ResultSerialData GetItems(Func<T, bool> predicate, string[] expand)
        {
            var result = new ResultSerialData()
            {
                Items = { },
                EntityTypeName = this.entityTypeName,
                TotalCount = 0,
                RelatedItems = { }
            };
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySetItems = this.dataContext.entitySets[this.entityTypeName].Items.Select((it) => it as T);
                result.Items = entitySetItems.Where(predicate).ToArray();
                DataViewLocalDtoUtils.FillResultRelatedItems(this.entityTypeName, result, expand, this.metadata);
            }
            return result;
        }

        public ResultSerialData GetMultipleItems(List<IEntity> partialEntities, string[] expand)
        {
            var result = new ResultSerialData()
            {
                Items = null,
                EntityTypeName = this.entityTypeName,
                TotalCount = 0,
                RelatedItems = { }
            };
            var item = default(object);
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var items = new List<object>();
                foreach (var partialEntity in partialEntities)
                {
                    var value = this.dataContext.entitySets[this.entityTypeName] as IEntitySet<IEntity>;
                    item = value.FindByKey(partialEntity);
                    if (item != null)
                    {
                        items.Add(item);
                    }
                }
                result.Items = items;
                DataViewLocalDtoUtils.FillResultRelatedItems(this.entityTypeName, result, expand, this.metadata);
            }
            return result;
        }

        public ResultSingleSerialData GetSingleItem(Func<T, bool> predicate, string[] expand)
        {
            var result = new ResultSingleSerialData()
            {
                Item = null,
                EntityTypeName = this.entityTypeName,
                RelatedItems = { }
            };
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySetItems = this.dataContext.entitySets[this.entityTypeName].Items.Select((it) => it as T);
                result.Item = entitySetItems.FirstOrDefault(predicate);
                DataViewLocalDtoUtils.FillResultSingleRelatedItems(this.entityTypeName, result, expand, this.metadata);
            }
            return result;
        }

        public ResultSingleSerialData GetSingleItem1(T partialEntity, string[] expand)
        {
            var result = new ResultSingleSerialData()
            {
                Item = null,
                EntityTypeName = this.entityTypeName,
                RelatedItems = { }
            };
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var value = this.dataContext.entitySets[this.entityTypeName] as IEntitySet<T>;
                result.Item = value.FindByKey(partialEntity /*partialEntity*/);
                DataViewLocalDtoUtils.FillResultSingleRelatedItems(this.entityTypeName, result, expand, this.metadata);
            }
            return result;
        }

        public T CreateItemDetached()
        {
            var item = this.dataContext.CreateItemDetached<T>(this.entityTypeName);
            return item;
        }

        public void DetachItem(T entity)
        {
            this.dataContext.entitySets[this.entityTypeName].DeleteEntity(entity);
        }

        public void DetachItems(T[] entities)
        {
            foreach (var entity in entities)
            {
                this.dataContext.entitySets[this.entityTypeName].DeleteEntity(entity);
            }
        }

        public void DetachAll()
        {
            this.dataContext.entitySets[this.entityTypeName].DeleteAll();
        }
    }

}