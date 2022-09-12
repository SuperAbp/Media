using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.Media.EntityFrameworkCore;

[ConnectionStringName(MediaDbProperties.ConnectionStringName)]
public interface IMediaDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
