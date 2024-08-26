namespace HPS_backoffice.Automapper
{
    using AutoMapper;
    using HPS_backoffice.DTOs.Client;
    using HPS_backoffice.Models;

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
                .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.Logo))
                .ReverseMap();
        }
    }

}
