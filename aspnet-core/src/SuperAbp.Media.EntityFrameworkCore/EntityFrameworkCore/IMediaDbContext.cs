using Microsoft.EntityFrameworkCore;
using SuperAbp.Media.MediaDescriptors;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.Media.EntityFrameworkCore;

[ConnectionStringName(MediaDbProperties.ConnectionStringName)]
public interface IMediaDbContext : IEfCoreDbContext
{
    public DbSet<MediaDescriptor> MediaDescriptors { get; set; }
}