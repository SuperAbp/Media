using Lzez.Tendering.Util.Encryption.Md5;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using SuperAbp.Media.Encryption.Md5;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;

namespace SuperAbp.Media.MediaDescriptors
{
    public class MediaDescriptorAppService : MediaAppService, IMediaDescriptorAppService
    {
        protected IBlobContainer<MediaContainer> BlobContainer { get; }
        protected IMediaDescriptorRepository MediaDescriptorRepository { get; }
        protected MediaDescriptorManager MediaDescriptorManager { get; }

        public MediaDescriptorAppService(IMediaDescriptorRepository mediaDescriptorRepository,
            IBlobContainer<MediaContainer> blobContainer,
            MediaDescriptorManager mediaDescriptorManager)
        {
            MediaDescriptorRepository = mediaDescriptorRepository;
            BlobContainer = blobContainer;
            MediaDescriptorManager = mediaDescriptorManager;
        }

        public virtual async Task<RemoteStreamContent> DownloadAsync(Guid id)
        {
            var entity = await MediaDescriptorRepository.GetAsync(id);
            var stream = await BlobContainer.GetAsync(id + Path.GetExtension(entity.Name));

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
                media.SetHash(HashAlgorithmHelper.ComputeHash<MD5>(Convert.ToString(buffer)));
                await BlobContainer.SaveAsync(media.Id + Path.GetExtension(inputStream.Name), stream);
                await MediaDescriptorRepository.InsertAsync(media);
                return ObjectMapper.Map<MediaDescriptor, MediaDescriptorDto>(media);
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await MediaDescriptorManager.DeleteAsync(id);
        }
    }
}