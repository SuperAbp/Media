using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.Media.EntityFrameworkCore;

public class MediaHttpApiHostMigrationsDbContext : AbpDbContext<MediaHttpApiHostMigrationsDbContext>
{
    public MediaHttpApiHostMigrationsDbContext(DbContextOptions<MediaHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureMedia();
    }
}
