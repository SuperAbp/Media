using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAbp.Media.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.Media.MediaDescriptors
{
    public class MediaDescriptorRepository : EfCoreRepository<MediaDbContext, MediaDescriptor, Guid>, IMediaDescriptorRepository
    {
        public MediaDescriptorRepository(IDbContextProvider<MediaDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<MediaDescriptor>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Set<MediaDescriptor>()
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();
        }

        public async Task DeleteByIdsAsync(IEnumerable<Guid> ids)
        {
            await DeleteAsync(m => ids.Contains(m.Id));
        }
    }
}