using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SuperAbp.Media;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MediaHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class MediaConsoleApiClientModule : AbpModule
{

}
