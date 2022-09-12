using SuperAbp.Media.MediaDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.Media.MediaDescriptors
{
    public interface IMediaDescriptorRepository : IRepository<MediaDescriptor, Guid>
    {
        Task<List<MediaDescriptor>> GetByIdsAsync(IEnumerable<Guid> ids);

        Task DeleteByIdsAsync(IEnumerable<Guid> ids);
    }
}
