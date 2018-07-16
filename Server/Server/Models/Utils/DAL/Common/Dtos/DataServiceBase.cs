using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Web.Hosting;

namespace Server.Models.Utils.DAL.Common
{
    public abstract class DataServiceBase
    {
        protected DataServiceBase(string pathMetadata, string connectionString)
        {
            if (string.IsNullOrEmpty(pathMetadata))
            {
                pathMetadata = HostingEnvironment.MapPath(@"~/App_Data");
            }

            var metadataJsonText = File.ReadAllText(Path.Combine(pathMetadata, "metadata_srv.json"));
            this.MetadataSrv = JsonConvert.DeserializeObject<MetadataSrv.Metadata>(metadataJsonText);

            //var metadataCliJsonText = File.ReadAllText(Path.Combine(pathMetadata, "metadata_cli_full.json"));
            //this.MetadataCliFull = JsonConvert.DeserializeObject<MetadataSrv.Metadata>(metadataCliJsonText);

            // in versiunea finala metadata va fi generata direct din baza de date
            //var connectionString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog=QualityControlDb04;Integrated Security=True;MultipleActiveResultSets=True";
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            this.DataAdapter = new DataAdapter(this.MetadataSrv, connectionString);
        }

        public MetadataSrv.Metadata MetadataSrv { get; private set; }

        //public MetadataSrv.Metadata MetadataCliFull { get; private set; }

        protected DataAdapter DataAdapter { get; private set; }
    }

}