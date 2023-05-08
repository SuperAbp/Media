using SuperAbp.Media.Localization;
using Volo.Abp.Application.Services;

namespace SuperAbp.Media;

public abstract class MediaAppService : ApplicationService
{
    protected MediaAppService()
    {
        LocalizationResource = typeof(MediaResource);
        ObjectMapperContext = typeof(SuperAbpMediaApplicationModule);
    }
}
