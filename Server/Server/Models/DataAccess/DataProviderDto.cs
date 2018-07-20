using NavyBlueDtos;

namespace Server.Models.DataAccess
{
    public static class DataProviderDto
    {
        public static DataServiceDto CreateDataServiceInstance()
        {
            var metadataSrv = DataProviderConfig.GetMetadataSrv();
            var connectionString = DataProviderConfig.GetConnectionString();
            var dataServiceDto = new DataServiceDto(metadataSrv, connectionString);
            return dataServiceDto;
        }
    }
}