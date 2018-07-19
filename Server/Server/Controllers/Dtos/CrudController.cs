using NavyBlueDtos;
using Newtonsoft.Json.Linq;
using Server.Models.DataAccess;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Server.Controllers.Dtos
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/datasource/crud")]
    public class CrudController : ApiController
    {
        public CrudController()
        {
            this.dataServiceDto = DataProviderDto.CreateDataServiceInstance();
        }

        private readonly DataServiceDto dataServiceDto;

        // GET: api/datasource/crud/{entitySetName}?skip=20&top=10
        [Route("{entitySetName}")]
        [HttpGet]
        public ResultSerialResponse Get(string entitySetName, [FromUri] QueryParams queryParams)
        {
            return this.dataServiceDto.ApiProviderDto.HandleGet(entitySetName, queryParams);
        }

        // GET: api/datasource/crud/single/{entitySetName}?keys=key1:{key1}
        [Route("single/{entitySetName}")]
        [HttpGet]
        public ResultSingleSerialData GetSingle(string entitySetName, [FromUri] QueryParams queryParams)
        {
            return this.dataServiceDto.ApiProviderDto.HandleGetSingle(entitySetName, queryParams);
        }

        // GET: api/datasource/crud/many/{entitySetName}?keys=key1:1,2,3,4;key2:4,5,6,7
        [Route("many/{entitySetName}")]
        [HttpGet]
        public ResultSerialData GetMany(string entitySetName, [FromUri] QueryParams queryParams)
        {
            return this.dataServiceDto.ApiProviderDto.HandleGetMany(entitySetName, queryParams);
        }

        // PUT: api/datasource/crud/{entitySetName}?keys=key1:{key1}
        [Route("{entitySetName}")]
        [HttpPut]
        public ResultSingleSerialData Put(string entitySetName, [FromUri] QueryParams queryParams, [FromBody] JObject jdto)
        {
            var dto = jdto.ToObject<Dto>();
            return this.dataServiceDto.ApiProviderDto.HandleUpdateEntity(entitySetName, queryParams, dto);
        }

        // PATCH: api/datasource/crud/{entitySetName}?keys=key1:{key1}
        [Route("{entitySetName}")]
        [HttpPatch]
        public ResultSingleSerialData Patch(string entitySetName, [FromUri] QueryParams queryParams, [FromBody] JObject jdto)
        {
            var dto = jdto.ToObject<Dto>();
            return this.dataServiceDto.ApiProviderDto.HandleUpdateEntity(entitySetName, queryParams, dto);
        }

        // POST: api/datasource/crud/{entitySetName}
        [Route("{entitySetName}")]
        [HttpPost]
        public ResultSingleSerialData Post(string entitySetName, [FromBody] JObject jdto)
        {
            var dto = jdto.ToObject<Dto>();
            return this.dataServiceDto.ApiProviderDto.HandleInsertEntity(entitySetName, dto);
        }

        // DELETE: api/datasource/crud/{entitySetName}?keys=key1:{key1}
        [Route("{entitySetName}")]
        [HttpDelete]
        public ResultSingleSerialData Delete(string entitySetName, [FromUri] QueryParams queryParams)
        {
            return this.dataServiceDto.ApiProviderDto.HandleDeleteEntity(entitySetName, queryParams);
        }

        // PUT: api/datasource/crud/batch/{entitySetName}
        [Route("batch/{entitySetName}")]
        [HttpPut]
        public List<ResultSingleSerialData> PutBatch(string entitySetName, [FromBody] JObject[] jdtos)
        {
            var dtos = new List<Dto>();
            foreach (var jdto in jdtos)
            {
                dtos.Add(jdto.ToObject<Dto>());
            }
            return this.dataServiceDto.ApiProviderDto.HandleUpdateEntityBatch(entitySetName, dtos.ToArray());
        }

        // PATCH: api/datasource/crud/batch/{entitySetName}
        [Route("{entitySetName}")]
        [HttpPatch]
        public List<ResultSingleSerialData> PatchBatch(string entitySetName, [FromBody] JObject[] jdtos)
        {
            var dtos = new List<Dto>();
            foreach (var jdto in jdtos)
            {
                dtos.Add(jdto.ToObject<Dto>());
            }
            return this.dataServiceDto.ApiProviderDto.HandleUpdateEntityBatch(entitySetName, dtos.ToArray());
        }

        // POST: api/datasource/crud/batch/{entitySetName}
        [Route("{entitySetName}")]
        [HttpPost]
        public List<ResultSingleSerialData> PostBatch(string entitySetName, [FromBody] JObject[] jdtos)
        {
            var dtos = new List<Dto>();
            foreach (var jdto in jdtos)
            {
                dtos.Add(jdto.ToObject<Dto>());
            }
            return this.dataServiceDto.ApiProviderDto.HandleInsertEntityBatch(entitySetName, dtos.ToArray());
        }

        //// DELETE: api/datasource/crud/batch/{entitySetName}
        //[Route("{entitySetName}")]
        //[HttpDelete]
        //public ResultSerialData DeleteBatch1(string entitySetName, [FromBody] JObject[] jdtos)
        //{
        //    var dtos = new List<Dto>();
        //    foreach (var jdto in jdtos)
        //    {
        //        dtos.Add(jdto.ToObject<Dto>());
        //    }
        //    return this.dataServiceDto.ApiProviderDto.HandleDeleteEntityBatch1(entitySetName, dtos.ToArray());
        //}

        // DELETE: api/datasource/crud/batch/{entitySetName}?keys=key1:1,2,3,4;key2:4,5,6,7
        [Route("{entitySetName}")]
        [HttpDelete]
        public ResultSerialData DeleteBatch(string entitySetName, [FromUri] QueryParams queryParams)
        {
            return this.dataServiceDto.ApiProviderDto.HandleDeleteEntityBatch(entitySetName, queryParams);
        }
    }
}
