using Server.Models.Utils.DAL;
using Server.Models.Utils.DAL.Common;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Server.Controllers.Dtos
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/datasource/operations")]
    public class CrudOperationsController : ApiController
    {
        public CrudOperationsController()
        {
            this.dataServiceDto = DataProviderDto.CreateDataServiceInstance();
        }

        private readonly DataServiceDto dataServiceDto;

        // GET: api/datasource/operations/GetFilmsWithActors?releaseYear=2006
        [Route("GetFilmsWithActors")]
        [HttpGet]
        public ResultSerialData Get([FromUri] int releaseYear)
        {
            //var expand = NavigationHelper<Film>.Get()
            //    .Include((it) => it.FilmActors.Select().Actor)
            //    .Include((it) => it.FilmCategories).All();

            var queryObject = new QueryObject()
            {
                Filter = string.Format("ReleaseYear='{0}'", releaseYear),
                Expand = new string[] { "FilmActors.Actor", "FilmCategories.Category" }
            };

            var resultSerialData = this.dataServiceDto.DataViewDto.GetItems("Film", queryObject);
            return resultSerialData;
            //var resultSerialResponse = ResultSerialUtils.FetchResponseData("Film", queryObject, "crud", this.dataServiceDto);
            //return resultSerialResponse;
        }

        // GET: api/datasource/operations/GetFilmsWithActors1?releaseYear=2006
        [Route("GetFilmsWithActors1")]
        [HttpGet]
        public ResultSerialData Get1([FromUri] int releaseYear)
        {
            var queryObject = new QueryObject()
            {
                Filter = string.Format("ReleaseYear='{0}'", releaseYear),
                Expand = new string[] { "FilmActors.Actor", "FilmCategories.Category" }
            };

            var dataService = DataService.CreateDataServiceInstance();

            var resultSerialData1 = dataService.From.Remote.DtoView.Films.GetItems(queryObject);
            var entities1 = dataService.From.Remote.EntityView.Films.GetItems(queryObject);
            var entities2 = dataService.From.Remote.EntityView.Films.GetItems(queryObject);
            //var derivedEntities = entities1.Select(it => new Film(it));

            foreach (var it in entities1)
            {
                var test0 = it.FilmId;
                var test1 = it.FilmActors;
                if (test1.Any())
                {
                    var test2 = test1.FirstOrDefault();
                    var test3 = test2.Actor;
                }
                var test4 = it.FilmCategories;
            }

            var entities3 = dataService.From.Local.EntityView.Films.GetItems(it => true); //.Select(it => new Film(it));
            var resultSerialData2 = dataService.From.Local.DtoView.Films.GetItems(it => true, queryObject.Expand);
            return resultSerialData2;
        }

        // POST: api/datasource/operations/TestAction
        // with: Content-Type: application/json and body - {"param1":1}
        [Route("TestAction")]
        [HttpPost]
        public void Post([FromBody] int param1)
        {
            // TODO: Add some actions in here
        }
    }
}
