
namespace NavyBlueDtos
{
    public class DataServiceDto
    {
        public MetadataSrv.Metadata MetadataSrv { get; private set; }
        public DataViewDto DataViewDto { get; private set; }
        public ApiProviderDto ApiProviderDto { get; private set; }
        public ResultSerialUtils ResultSerialUtils { get; private set; }

        public DataServiceDto(MetadataSrv.Metadata metadataSrv, string connectionString)
        {
            this.MetadataSrv = metadataSrv;

            var dialect = metadataSrv.Dialect();
            var databaseOperations = new DatabaseOperations(dialect, connectionString);
            var dataAdapterRead = new DataAdapterRead(metadataSrv, dialect, databaseOperations);
            var dataAdapterCud = new DataAdapterCud(metadataSrv, dialect, dataAdapterRead, databaseOperations);
            this.DataViewDto = new DataViewDto(metadataSrv, dataAdapterRead, dataAdapterCud);
            this.ResultSerialUtils = new ResultSerialUtils("crud", metadataSrv, this.DataViewDto);
            this.ApiProviderDto = new ApiProviderDto(metadataSrv, this.DataViewDto, this.ResultSerialUtils);
        }

    }

}