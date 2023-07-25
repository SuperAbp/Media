using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using SuperAbp.Media.MediaDescriptors;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace SuperAbp.Media.EntityFrameworkCore.MediaDescriptors;

public sealed class MediaDescriptorRepositoryTests : MediaEntityFrameworkCoreTestBase
{
    private readonly MediaTestData _mediaTestData;
    private readonly IMediaDescriptorRepository _mediaDescriptorRepository;

    public MediaDescriptorRepositoryTests()
    {
        _mediaTestData = GetRequiredService<MediaTestData>();
        _mediaDescriptorRepository = GetRequiredService<IMediaDescriptorRepository>();
    }

    [Fact]
    public async Task Should_GetByIds()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            //Act
            var medias = await _mediaDescriptorRepository.GetByIdsAsync(new[] { _mediaTestData.Media1Id });

            //Assert
            medias.ShouldNotBeNull();
            medias.Count.ShouldBeGreaterThan(0);
        });
    }
}