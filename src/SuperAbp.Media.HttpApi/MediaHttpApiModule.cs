using Localization.Resources.AbpUi;
using SuperAbp.Media.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace SuperAbp.Media;

[DependsOn(
    typeof(MediaApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class MediaHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MediaHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MediaResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
