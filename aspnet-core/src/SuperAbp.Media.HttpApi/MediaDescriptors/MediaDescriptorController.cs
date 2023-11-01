using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Content;

namespace SuperAbp.Media.MediaDescriptors;

[RemoteService(Name = MediaRemoteServiceConsts.RemoteServiceName)]
[Area(MediaRemoteServiceConsts.ModuleName)]
[Route("api/super-abp/media")]
public class MediaDescriptorController : MediaController, IMediaDescriptorAppService
{
    protected IMediaDescriptorAppService MediaDescriptorAppService { get; }

    public MediaDescriptorController(IMediaDescriptorAppService mediaDescriptorAppService)
    {
        MediaDescriptorAppService = mediaDescriptorAppService;
    }

    /// <summary>
    /// 下载
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<RemoteStreamContent> DownloadAsync(Guid id)
    {
        return await MediaDescriptorAppService.DownloadAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="inputStream"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<MediaDescriptorDto> CreateAsync(CreateMediaInputWithStream inputStream)
    {
        return await MediaDescriptorAppService.CreateAsync(inputStream);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}", Name = nameof(DeleteAsync))]
    public virtual async Task DeleteAsync(Guid id)
    {
        await MediaDescriptorAppService.DeleteAsync(id);
    }
}