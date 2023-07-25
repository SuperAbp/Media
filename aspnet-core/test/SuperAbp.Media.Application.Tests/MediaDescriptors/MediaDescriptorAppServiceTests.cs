using System.Threading.Tasks;
using System;
using System.Linq;
using Shouldly;
using Xunit;
using System.IO;
using System.Text;
using Volo.Abp.Content;

namespace SuperAbp.Media.MediaDescriptors;

public sealed class MediaDescriptorAppServiceTests : MediaApplicationTestBase
{
    private readonly MediaTestData _mediaTestData;
    private readonly IMediaDescriptorRepository _mediaDescriptorRepository;
    private readonly IMediaDescriptorAppService _mediaDescriptorAppService;

    public MediaDescriptorAppServiceTests()
    {
        _mediaTestData = GetRequiredService<MediaTestData>();
        _mediaDescriptorRepository = GetRequiredService<IMediaDescriptorRepository>();
        _mediaDescriptorAppService = GetRequiredService<IMediaDescriptorAppService>();
    }

    [Fact]
    public async Task Should_Create()
    {
        var mediaName = "test1.txt";
        var mediaType = "text/plain";
        var mediaContent = "test content";

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(mediaContent));

        var mediaLength = stream.Length;

        var media = await _mediaDescriptorAppService.CreateAsync(new CreateMediaInputWithStream()
        {
            File = new RemoteStreamContent(stream, mediaName, mediaType),
            Name = mediaName
        });

        media.ShouldNotBeNull();

        UsingDbContext(context =>
        {
            var mediaDescriptor = context.MediaDescriptors.FirstOrDefault(q => q.Id == media.Id);
            mediaDescriptor.ShouldNotBeNull();
            mediaDescriptor.MimeType.ShouldBe(mediaType);
            mediaDescriptor.Name.ShouldBe(mediaName);
            mediaDescriptor.Size.ShouldBe(mediaLength);
        });
    }

    [Fact]
    public async Task Should_Delete()
    {
        await _mediaDescriptorAppService.DeleteAsync(_mediaTestData.Media1Id);

        (await _mediaDescriptorRepository.FindAsync(_mediaTestData.Media1Id)).ShouldBeNull();
    }
}