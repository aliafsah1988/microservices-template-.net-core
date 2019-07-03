using AutoMapper;
using ServiceA.Data.Entities;

namespace ServiceA.Business.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceA.Business.Domain.SomeModel, SomeEntity>()
                .ForMember(dest => dest.AppId, opt => opt.MapFrom(o => o.AppId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(o => o.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(o => o.FullName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(o => o.MiddleName))
                .ForMember(dest => dest.Output, opt => opt.MapFrom(o => o.Output))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(o => o.Phone));
        }
    }
}
