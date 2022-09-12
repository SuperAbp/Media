using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAbp.Media.MediaDescriptors;
using Volo.Abp;
using Volo.Abp.Content;

namespace SuperAbp.Media.Controllers
{
    [RemoteService(Name = MediaRemoteServiceConsts.RemoteServiceName)]
    [Area(MediaRemoteServiceConsts.ModuleName)]
    [Route("api/super-abp/media")]
    public class MediaDescriptorController : MediaController
    {
        private readonly IMediaDescriptorAppService _mediaDescriptorAppService;

        public MediaDescriptorController(IMediaDescriptorAppService mediaDescriptorAppService)
        {
            _mediaDescriptorAppService = mediaDescriptorAppService;
        }

        [HttpGet("{id}")]
        public virtual async Task<RemoteStreamContent> DownloadAsync(Guid id)
        {
            return await _mediaDescriptorAppService.DownloadAsync(id);
        }

        [HttpPost]
        public virtual async Task<MediaDescriptorDto> CreateAsync(CreateMediaInputWithStream inputStream)
        {
            return await _mediaDescriptorAppService.CreateAsync(inputStream);
        }

        [HttpDelete("{id}", Name = nameof(DeleteAsync))]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _mediaDescriptorAppService.DeleteAsync(id);
        }
    }
}
