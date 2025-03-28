using AutoMapper;
using ToDo.Shared.DataTransfer;
using ToDo.Shared;

namespace ToDo.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shared.Entities.WorkItem, Shared.DataTransfer.WorkItem>()
                .ForMember(
                    dest => dest.IsMine,
                    opt => opt.MapFrom(src => src.CreatedBy == "Steven")
                );
            CreateMap<Shared.DataTransfer.WorkItem, Shared.Entities.WorkItem>();
        }
    }
}
