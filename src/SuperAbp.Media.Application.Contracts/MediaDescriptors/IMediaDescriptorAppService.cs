using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace SuperAbp.Media.MediaDescriptors
{
    public interface IMediaDescriptorAppService:IApplicationService
    {
        Task<RemoteStreamContent> DownloadAsync(Guid id);

        Task<MediaDescriptorDto> CreateAsync(CreateMediaInputWithStream inputStream);

        Task DeleteAsync(Guid id);
    }
}
