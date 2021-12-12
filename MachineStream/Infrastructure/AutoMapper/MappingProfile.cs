namespace MachineStream.Infrastructure.AutoMapper
{
    using Domain.Entities;
    using Domain.Model;
    using global::AutoMapper;
    using Model;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventDataModel, EventEntity>();
            CreateMap<MachineEntity, MachineResponse>();
            CreateMap<EventEntity, EventResponse>();
            CreateMap<EventEntity, EventExtendedResponse>();
            CreateMap<MachineEntity, MachineExtendedModel>().ForMember(dest => dest.Events, act => act.Ignore());
            CreateMap<MachineExtendedModel, MachineExtendedResponse>()
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));
        }
    }
}