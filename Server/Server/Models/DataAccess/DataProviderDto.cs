using NavyBlueDtos;

namespace Server.Models.DataAccess
{
    public static class DataProviderDto
    {
        public static DataServiceDto CreateDataServiceInstance()
        {
            var connectionString = DataProviderConfig.GetConnectionString();
            var metadataSrv = DataProviderConfig.GetMetadataSrv();
            var dataServiceDto = new DataServiceDto(connectionString, metadataSrv);
            return dataServiceDto;
        }
    }
}