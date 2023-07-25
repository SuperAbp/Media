using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.Media.MediaDescriptors
{
    public class MediaDescriptor : Entity<Guid>
    {
        public MediaDescriptor(Guid id, string name, string mimeType, long size) : base(id)
        {
            Name = name;
            MimeType = mimeType;
            Size = size;
        }

        public string Name { get; protected set; }

        public string MimeType { get; protected set; }

        public long Size { get; protected set; }

        public string Hash { get; protected set; }

        public void SetHash(string hash)
        {
            this.Hash = hash ?? throw new ArgumentNullException(nameof(hash));
        }
    }
}