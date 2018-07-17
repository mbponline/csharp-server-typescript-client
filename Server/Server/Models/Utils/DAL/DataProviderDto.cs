namespace Server.Models.Utils.DAL.Common
{
    public static class DataProviderDto
    {
        public static DataServiceDto CreateDataServiceInstance()
        {
            var dataServiceDto = new DataServiceDto();
            return dataServiceDto;
        }
    }
}