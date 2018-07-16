namespace Server.Models.Utils.DAL.Common
{
    public abstract class DataServiceEntity<TLocalEntity, TLocalDto, TRemoteEntity, TRemoteDto> : DataServiceDto
        where TLocalEntity : LocalEntityViewsBase
        where TLocalDto : LocalDtoViewsBase
        where TRemoteEntity : RemoteEntityViewsBase
        where TRemoteDto : RemoteDtoViewsBase
    {
        protected DataServiceEntity(string metadataFileName = "", string connectionString = "")
            : base(metadataFileName, connectionString)
        {
            this.DataContext = new DataContext(this.MetadataSrv);
        }

        public DataContext DataContext { get; private set; }

        public ServiceLocation<TLocalEntity, TLocalDto, TRemoteEntity, TRemoteDto> From { get; set; }
    }

}