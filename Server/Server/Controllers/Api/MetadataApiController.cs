using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Server.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MetadataApiController : ApiController
    {
        // GET: api/datasource/metadata
        [Route("api/datasource/metadata")]
        [HttpGet]
        public HttpResponseMessage GetMetadata()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data");
            var fileName = Path.Combine(path, "metadata_cli.json");
            var result = Request.CreateResponse(HttpStatusCode.OK);
            var stream = new FileStream(fileName, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return result;
        }

    }
}
