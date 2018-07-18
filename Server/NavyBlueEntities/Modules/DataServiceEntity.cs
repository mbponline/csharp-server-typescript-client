using NavyBlueDtos;

namespace NavyBlueEntities
{
    public abstract class DataServiceEntity<TLocalEntity, TLocalDto, TRemoteEntity, TRemoteDto> : DataServiceDto
        where TLocalEntity : LocalEntityViewsBase
        where TLocalDto : LocalDtoViewsBase
        where TRemoteEntity : RemoteEntityViewsBase
        where TRemoteDto : RemoteDtoViewsBase
    {
        public DataContext DataContext { get; private set; }
        public ServiceLocation<TLocalEntity, TLocalDto, TRemoteEntity, TRemoteDto> From { get; set; }

        protected DataServiceEntity(string pathMetadata, string connectionString)
            : base(pathMetadata, connectionString)
        {
            this.DataContext = new DataContext(this.MetadataSrv);
        }

    }

}