using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SuperAbp.Media;

[DependsOn(
    typeof(MediaApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class MediaHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MediaApplicationContractsModule).Assembly,
            MediaRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MediaHttpApiClientModule>();
        });

    }
}
