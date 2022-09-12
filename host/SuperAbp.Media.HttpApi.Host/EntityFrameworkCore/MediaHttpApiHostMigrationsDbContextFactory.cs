using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SuperAbp.Media.EntityFrameworkCore;

public class MediaHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<MediaHttpApiHostMigrationsDbContext>
{
    public MediaHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MediaHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("SuperAbpMedia"));

        return new MediaHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
