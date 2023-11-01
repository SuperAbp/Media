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
        protected IBlobContainer<MediaContainer> BlobContainer { get; }
        protected IMediaDescriptorRepository MediaDescriptorRepository { get; }

        public MediaDescriptorManager(IMediaDescriptorRepository mediaDescriptorRepository,
            IBlobContainer<MediaContainer> blobContainer)
        {
            MediaDescriptorRepository = mediaDescriptorRepository;
            BlobContainer = blobContainer;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(Guid id)
        {
            await BlobContainer.DeleteAsync(id.ToString());
            await MediaDescriptorRepository.DeleteAsync(id);
        }
    }
}