using Volo.Abp.Modularity;

namespace SuperAbp.Media;

[DependsOn(
    typeof(SuperAbpMediaApplicationModule),
    typeof(MediaDomainTestModule)
    )]
public class MediaApplicationTestModule : AbpModule
{
}