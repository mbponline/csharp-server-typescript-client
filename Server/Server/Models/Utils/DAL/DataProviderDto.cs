using System.Configuration;
using System.Web.Hosting;

namespace Server.Models.Utils.DAL.Common
{
    public static class DataProviderDto
    {
        public static DataServiceDto CreateDataServiceInstance()
        {
            var pathMetadata = HostingEnvironment.MapPath(@"~/App_Data");
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dataServiceDto = new DataServiceDto(pathMetadata, connectionString);
            return dataServiceDto;
        }
    }
}