using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace SuperAbp.Media.MediaDescriptors
{
    public interface IMediaDescriptorAppService : IApplicationService
    {
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RemoteStreamContent> DownloadAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        Task<MediaDescriptorDto> CreateAsync(CreateMediaInputWithStream inputStream);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}