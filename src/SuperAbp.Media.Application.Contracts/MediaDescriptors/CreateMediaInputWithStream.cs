using System.ComponentModel.DataAnnotations;
using Volo.Abp.Content;
using Volo.Abp.Validation;

namespace SuperAbp.Media.MediaDescriptors
{
    public class CreateMediaInputWithStream
    {
        [Required]
        [DynamicStringLength(typeof(MediaDescriptorConsts), nameof(MediaDescriptorConsts.MaxNameLength))]
        public string Name { get; set; }

        [Required]
        public IRemoteStreamContent File { get; set; }
    }
}