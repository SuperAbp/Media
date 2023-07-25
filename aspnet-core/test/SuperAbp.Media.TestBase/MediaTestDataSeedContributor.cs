using SuperAbp.Media.MediaDescriptors;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace SuperAbp.Media;

public class MediaTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly MediaTestData _mediaTestData;
    private readonly IMediaDescriptorRepository _mediaDescriptorRepository;
    private readonly IBlobContainer<MediaContainer> _mediaBlobContainer;

    public MediaTestDataSeedContributor(MediaTestData mediaTestData,
        IMediaDescriptorRepository mediaDescriptorRepository, IBlobContainer<MediaContainer> mediaBlobContainer)
    {
        _mediaTestData = mediaTestData;
        _mediaDescriptorRepository = mediaDescriptorRepository;
        _mediaBlobContainer = mediaBlobContainer;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedMediaAsync();
    }

    private async Task SeedMediaAsync()
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(_mediaTestData.Media1Content));
        var media = new MediaDescriptor(_mediaTestData.Media1Id, _mediaTestData.Media1Name, _mediaTestData.Media1ContentType, stream.Length);

        await _mediaDescriptorRepository.InsertAsync(media);

        await _mediaBlobContainer.SaveAsync(media.Id.ToString(), stream);
    }
}