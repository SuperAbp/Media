using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SuperAbp.Media;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(MediaDomainSharedModule)
)]
public class MediaDomainModule : AbpModule
{

}
