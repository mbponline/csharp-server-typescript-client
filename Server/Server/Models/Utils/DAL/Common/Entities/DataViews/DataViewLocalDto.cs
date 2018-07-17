using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Models.Utils.DAL.Common
{
    public class DataViewLocalDto
    {
        private readonly string entityTypeName;
        private readonly DataContext dataContext;
        private readonly MetadataSrv.Metadata metadataSrv;

        public DataViewLocalDto(string entityTypeName, DataContext dataContext, MetadataSrv.Metadata metadataSrv)
        {
            this.entityTypeName = entityTypeName;
            this.dataContext = dataContext;
            this.metadataSrv = metadataSrv;
        }

        public ResultSerialData GetItems(Func<Entity, bool> predicate, string[] expand)
        {
            var resultSerialData = new ResultSerialData()
            {
                Items = { },
                EntityTypeName = this.entityTypeName,
                TotalCount = 0,
                RelatedItems = { }
            };
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                var entities = entitySet.Filter(predicate);
                resultSerialData.Items = entities.Select((it) => it.dto).ToList();
                DataViewLocalDtoUtils.FillResultRelatedItems(this.entityTypeName, resultSerialData, expand, this.dataContext, this.metadataSrv);
            }
            return resultSerialData;
        }

        public ResultSerialData GetMultipleItems(IEnumerable<Dto> partialDtos, string[] expand)
        {
            var resultSerialData = new ResultSerialData()
            {
                Items = null,
                EntityTypeName = this.entityTypeName,
                TotalCount = 0,
                RelatedItems = { }
            };
            var entity = default(Entity);
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var dtos = new List<Dto>();
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                foreach (var partialDto in partialDtos)
                {
                    entity = entitySet.FindByKey(partialDto);
                    if (entity != null)
                    {
                        dtos.Add(entity.dto);
                    }
                }
                resultSerialData.Items = dtos;
                DataViewLocalDtoUtils.FillResultRelatedItems(this.entityTypeName, resultSerialData, expand, this.dataContext, this.metadataSrv);
            }
            return resultSerialData;
        }

        public ResultSingleSerialData GetSingleItem(Func<Entity, bool> predicate, string[] expand)
        {
            var resultSingleSerialData = new ResultSingleSerialData()
            {
                Item = null,
                EntityTypeName = this.entityTypeName,
                RelatedItems = { }
            };
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                var entity = entitySet.Find(predicate);
                resultSingleSerialData.Item = entity.dto;
                DataViewLocalDtoUtils.FillResultSingleRelatedItems(this.entityTypeName, resultSingleSerialData, expand, this.dataContext, this.metadataSrv);
            }
            return resultSingleSerialData;
        }

        public ResultSingleSerialData GetSingleItem1(Dto partialDto, string[] expand)
        {
            var resultSingleSerialData = new ResultSingleSerialData()
            {
                Item = null,
                EntityTypeName = this.entityTypeName,
                RelatedItems = { }
            };
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                var entity = entitySet.FindByKey(partialDto /*partialEntity*/);
                resultSingleSerialData.Item = entity.dto;
                DataViewLocalDtoUtils.FillResultSingleRelatedItems(this.entityTypeName, resultSingleSerialData, expand, this.dataContext, this.metadataSrv);
            }
            return resultSingleSerialData;
        }

        //public T CreateItemDetached()
        //{
        //    var item = this.dataContext.CreateItemDetached<T>(this.entityTypeName);
        //    return item;
        //}

        //public void DetachItem(T entity)
        //{
        //    this.dataContext.entitySets[this.entityTypeName].DeleteEntity(entity);
        //}

        //public void DetachItems(T[] entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        this.dataContext.entitySets[this.entityTypeName].DeleteEntity(entity);
        //    }
        //}

        //public void DetachAll()
        //{
        //    this.dataContext.entitySets[this.entityTypeName].DeleteAll();
        //}
    }

}