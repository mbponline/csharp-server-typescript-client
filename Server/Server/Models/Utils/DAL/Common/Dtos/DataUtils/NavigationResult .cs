
namespace Server.Models.Utils.DAL.Common
{

    public class NavigationResult
    {
        public string EntityTypeName { get; set; }

        public MetadataSrv.NavigationProperty NavigationProperty { get; set; }

        public string Filter { get; set; }
    }

}