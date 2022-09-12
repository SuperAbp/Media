using SuperAbp.Media.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SuperAbp.Media.Controllers;

public abstract class MediaController : AbpControllerBase
{
    protected MediaController()
    {
        LocalizationResource = typeof(MediaResource);
    }
}
