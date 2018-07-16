using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Web.Hosting;

namespace Server.Models.Utils.DAL.Common
{
    public class DataServiceDto
    {
        public MetadataSrv.Metadata MetadataSrv { get; private set; }
        public DataViewDto DataViewDto { get; private set; }

        public DataServiceDto(string pathMetadata = "", string connectionString = "")
        {
            if (string.IsNullOrEmpty(pathMetadata))
            {
                pathMetadata = HostingEnvironment.MapPath(@"~/App_Data");
            }

            var metadataJsonText = File.ReadAllText(Path.Combine(pathMetadata, "metadata_srv.json"));
            this.MetadataSrv = JsonConvert.DeserializeObject<MetadataSrv.Metadata>(metadataJsonText);

            // in versiunea finala metadata va fi generata direct din baza de date
            //var connectionString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog=QualityControlDb04;Integrated Security=True;MultipleActiveResultSets=True";
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }

            var dialect = this.MetadataSrv.Dialect();
            var databaseOperations = new DatabaseOperations(dialect, connectionString);
            var dataAdapterRead = new DataAdapterRead(this.MetadataSrv, dialect, databaseOperations);
            var dataAdapterCud = new DataAdapterCud(this.MetadataSrv, dialect, dataAdapterRead, databaseOperations);
            this.DataViewDto = new DataViewDto(this.MetadataSrv, dataAdapterRead, dataAdapterCud);
        }

    }

}