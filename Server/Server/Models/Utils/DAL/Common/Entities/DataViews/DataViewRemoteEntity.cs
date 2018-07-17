using System.Collections.Generic;
using System.Linq;

namespace Server.Models.Utils.DAL.Common
{

    public class DataViewRemoteEntity
    {
        private readonly string entityTypeName;
        private readonly DataViewDto dataViewDto;
        private readonly DataContext dataContext;

        public DataViewRemoteEntity(string entityTypeName, DataViewDto dataViewDto, DataContext dataContext)
        {
            this.entityTypeName = entityTypeName;
            this.dataViewDto = dataViewDto;
            this.dataContext = dataContext;
        }

        public int Count(QueryObject queryObject)
        {
            return this.dataViewDto.Count(this.entityTypeName, queryObject);
        }

        public IEnumerable<Entity> GetItems(QueryObject queryObject)
        {
            var resultSerialData = this.dataViewDto.GetItems(this.entityTypeName, queryObject);
            var entities = this.dataContext.AttachEntities(resultSerialData);
            return entities;
        }

        public Entity GetSingleItem(Dto partialDto, string[] expand = null)
        {
            var resultSingleSerialData = this.dataViewDto.GetSingleItem(this.entityTypeName, partialDto, expand);
            var entity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
            return entity;
        }

        public IEnumerable<Entity> GetMultipleItems(IEnumerable<Dto> partialDtos, string[] expand = null)
        {
            var resultSerialData = this.dataViewDto.GetMultipleItems(this.entityTypeName, partialDtos, expand);
            var entities = this.dataContext.AttachEntities(resultSerialData);
            return entities;
        }

        public Entity InsertItem(Dto dto)
        {
            var resultSingleSerialData = this.dataViewDto.InsertItem(this.entityTypeName, dto);
            var entity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
            return entity;
        }

        public IEnumerable<Entity> InsertItems(IEnumerable<Dto> dtos)
        {
            var entities = new List<Entity>();
            var resultSingleSerialDataList = this.dataViewDto.InsertItems(this.entityTypeName, dtos);
            foreach (var resultSingleSerialData in resultSingleSerialDataList)
            {
                var entity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
                entities.Add(entity);
            }
            return entities;
        }

        public Entity UpdateItem(Dto partialDto)
        {
            var resultSingleSerialData = this.dataViewDto.UpdateItem(this.entityTypeName, partialDto);
            var entity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
            return entity;
        }

        public IEnumerable<Entity> UpdateItems(IEnumerable<Dto> partialDtos)
        {
            var entities = new List<Entity>();
            var resultSingleSerialDataList = this.dataViewDto.UpdateItems(this.entityTypeName, partialDtos);
            foreach (var resultSingleSerialData in resultSingleSerialDataList)
            {
                var entity = this.dataContext.AttachSingleEntitiy(resultSingleSerialData);
                entities.Add(entity);
            }
            return entities;
        }

        public Entity DeleteItem(Dto partialDto)
        {
            var resultSingleSerialData = this.dataViewDto.DeleteItem(this.entityTypeName, partialDto);
            var entity = default(Entity);
            if (this.dataContext.entitySets.ContainsKey(this.entityTypeName))
            {
                var entitySet = this.dataContext.entitySets[this.entityTypeName];
                entity = entitySet.FindByKey(partialDto);
                if (entity != null)
                {
                    entitySet.DeleteEntity(entity);
                }
            }
            return entity;
        }

        public IEnumerable<Entity> DeleteItems(IEnumerable<Dto> partialDtos)
        {
            var resultSerialData = this.dataViewDto.DeleteItems(this.entityTypeName, partialDtos);
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
                        entitySet.DeleteEntity(entity);
                    }
                }
            }
            return entities;
        }
    }

}