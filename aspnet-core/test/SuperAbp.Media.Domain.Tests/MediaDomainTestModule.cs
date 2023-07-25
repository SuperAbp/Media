using SuperAbp.Media.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SuperAbp.Media;

[DependsOn(
    typeof(MediaEntityFrameworkCoreTestModule)
    )]
public class MediaDomainTestModule : AbpModule
{

}
