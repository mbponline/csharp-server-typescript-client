using Newtonsoft.Json;
using System.IO;

namespace NavyBlueDtos
{
    public class DataServiceDto
    {
        public MetadataSrv.Metadata MetadataSrv { get; private set; }
        public DataViewDto DataViewDto { get; private set; }

        public DataServiceDto(string pathMetadata, string connectionString)
        {
            var metadataJsonText = File.ReadAllText(Path.Combine(pathMetadata, "metadata_srv.json"));
            this.MetadataSrv = JsonConvert.DeserializeObject<MetadataSrv.Metadata>(metadataJsonText);

            var dialect = this.MetadataSrv.Dialect();
            var databaseOperations = new DatabaseOperations(dialect, connectionString);
            var dataAdapterRead = new DataAdapterRead(this.MetadataSrv, dialect, databaseOperations);
            var dataAdapterCud = new DataAdapterCud(this.MetadataSrv, dialect, dataAdapterRead, databaseOperations);
            this.DataViewDto = new DataViewDto(this.MetadataSrv, dataAdapterRead, dataAdapterCud);
        }

    }

}