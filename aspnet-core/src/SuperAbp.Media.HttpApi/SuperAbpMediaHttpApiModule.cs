using Localization.Resources.AbpUi;
using SuperAbp.Media.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using SuperAbp.Media.MediaDescriptors;

namespace SuperAbp.Media;

[DependsOn(
    typeof(SuperAbpMediaApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SuperAbpMediaHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SuperAbpMediaHttpApiModule).Assembly);
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
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.FormBodyBindingIgnoredTypes.Add(typeof(CreateMediaInputWithStream));
        });
    }
}