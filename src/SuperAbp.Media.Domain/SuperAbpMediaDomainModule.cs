using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SuperAbp.Media;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SuperAbpMediaDomainSharedModule)
)]
public class SuperAbpMediaDomainModule : AbpModule
{
}