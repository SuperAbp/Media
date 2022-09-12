using SuperAbp.Media.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SuperAbp.Media;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(MediaEntityFrameworkCoreTestModule)
    )]
public class MediaDomainTestModule : AbpModule
{

}
