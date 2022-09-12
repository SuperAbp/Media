using System;
using System.IO;
using System.Threading.Tasks;
using Snow.Tools.Security.Cryptography;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace SuperAbp.Media.MediaDescriptors
{
    public class MediaDescriptorAppService : MediaAppService, IMediaDescriptorAppService
    {
        private readonly IBlobContainer<MediaContainer> _blobContainer;
        private readonly IMediaDescriptorRepository _mediaDescriptorRepository;

        public MediaDescriptorAppService(IMediaDescriptorRepository mediaDescriptorRepository,
            IBlobContainer<MediaContainer> blobContainer)
        {
            _mediaDescriptorRepository = mediaDescriptorRepository;
            _blobContainer = blobContainer;
        }

        public virtual async Task<RemoteStreamContent> DownloadAsync(Guid id)
        {
            var entity = await _mediaDescriptorRepository.GetAsync(id);
            var stream = await _blobContainer.GetAsync(id + Path.GetExtension(entity.Name));

            return new RemoteStreamContent(stream, entity.Name, entity.MimeType);
        }

        public virtual async Task<MediaDescriptorDto> CreateAsync(CreateMediaInputWithStream inputStream)
        {
            // TODO:判断文件是否存在,使用MD5值判断，先不做
            using (var stream = inputStream.File.GetStream())
            {
                var media = new MediaDescriptor(GuidGenerator.Create(), inputStream.Name, inputStream.File.ContentType,
                    inputStream.File.ContentLength ?? 0);

                var buffer = await stream.GetAllBytesAsync();
                media.SetHash(MD5Encryption.MD5Encrypt(buffer));
                await _blobContainer.SaveAsync(media.Id + Path.GetExtension(inputStream.Name), stream);
                await _mediaDescriptorRepository.InsertAsync(media);
                return ObjectMapper.Map<MediaDescriptor, MediaDescriptorDto>(media);
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _blobContainer.DeleteAsync(id.ToString());
            await _mediaDescriptorRepository.DeleteAsync(id);
        }
    }
}