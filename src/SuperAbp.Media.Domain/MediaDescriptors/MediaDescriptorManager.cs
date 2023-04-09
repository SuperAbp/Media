using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Services;

namespace SuperAbp.Media.MediaDescriptors
{
    public class MediaDescriptorManager : DomainService
    {
        private readonly IBlobContainer<MediaContainer> _blobContainer;
        private readonly IMediaDescriptorRepository _mediaDescriptorRepository;

        public MediaDescriptorManager(IMediaDescriptorRepository mediaDescriptorRepository,
            IBlobContainer<MediaContainer> blobContainer)
        {
            _mediaDescriptorRepository = mediaDescriptorRepository;
            _blobContainer = blobContainer;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _blobContainer.DeleteAsync(id.ToString());
            await _mediaDescriptorRepository.DeleteAsync(id);
        }
    }
}