using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SuperAbp.Media;

[DependsOn(
    typeof(SuperAbpMediaDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SuperAbpMediaApplicationContractsModule : AbpModule
{
}