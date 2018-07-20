using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Web.Hosting;
using MetadataSrv = NavyBlueDtos.MetadataSrv;

namespace Server.Models.DataAccess
{

    public static class DataProviderConfig
    {

        public static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return connectionString;
        }

        public static MetadataSrv.Metadata GetMetadataSrv()
        {
            var pathMetadata = HostingEnvironment.MapPath(@"~/App_Data");
            var metadataJsonText = File.ReadAllText(Path.Combine(pathMetadata, "metadata_srv.json"));
            var metadataSrv = JsonConvert.DeserializeObject<MetadataSrv.Metadata>(metadataJsonText);
            return metadataSrv;
        }

    }

}