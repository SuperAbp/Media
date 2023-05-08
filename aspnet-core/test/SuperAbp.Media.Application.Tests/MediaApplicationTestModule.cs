using Volo.Abp.Modularity;

namespace SuperAbp.Media;

[DependsOn(
    typeof(MediaApplicationModule),
    typeof(MediaDomainTestModule)
    )]
public class MediaApplicationTestModule : AbpModule
{

}
