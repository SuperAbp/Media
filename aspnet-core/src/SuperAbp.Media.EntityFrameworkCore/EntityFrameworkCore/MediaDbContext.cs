using Microsoft.EntityFrameworkCore;
using SuperAbp.Media.MediaDescriptors;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.Media.EntityFrameworkCore;

[ConnectionStringName(MediaDbProperties.ConnectionStringName)]
public class MediaDbContext : AbpDbContext<MediaDbContext>, IMediaDbContext
{
    public DbSet<MediaDescriptor> MediaDescriptors { get; set; }

    public MediaDbContext(DbContextOptions<MediaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureMedia();
    }
}