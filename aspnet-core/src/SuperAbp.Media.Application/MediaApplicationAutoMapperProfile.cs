using AutoMapper;
using SuperAbp.Media.MediaDescriptors;

namespace SuperAbp.Media;

public class MediaApplicationAutoMapperProfile : Profile
{
    public MediaApplicationAutoMapperProfile()
    {
            CreateMap<MediaDescriptor, MediaDescriptorDto>();
    }
}
