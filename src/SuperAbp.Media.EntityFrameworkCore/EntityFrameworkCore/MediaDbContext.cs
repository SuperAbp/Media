using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.Media.EntityFrameworkCore;

[ConnectionStringName(MediaDbProperties.ConnectionStringName)]
public class MediaDbContext : AbpDbContext<MediaDbContext>, IMediaDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

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
