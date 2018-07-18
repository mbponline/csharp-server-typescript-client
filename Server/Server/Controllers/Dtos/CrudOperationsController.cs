using Server.Models.Utils.DAL.Common;
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
