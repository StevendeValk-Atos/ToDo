using AutoMapper;
using ToDo.Shared.DataTransfer;

namespace ToDo.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shared.Entities.WorkItem, Shared.DataTransfer.WorkItem>()
                .ForMember(
                dest => dest.IsMine,
                opt => opt.MapFrom(src => src.CreatedBy == "Steven" ? true : false));
            CreateMap<Shared.Entities.WorkItem, WorkItem>().ReverseMap();
        }
    }
}
