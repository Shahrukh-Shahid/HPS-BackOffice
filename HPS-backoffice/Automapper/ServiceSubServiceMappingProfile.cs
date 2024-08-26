using AutoMapper;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.Models;

namespace HPS_backoffice.Automapper
{
    public class ServiceSubServiceMappingProfile : Profile
    {
        public ServiceSubServiceMappingProfile()
        {
            // Mapping from ServiceSubServiceDto to ServiceSubService
            CreateMap<ServiceSubServiceDto, ServiceSubService>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id for updates
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted ?? false)) // Handle IsDeleted default
                .ForMember(dest => dest.Service, opt => opt.Ignore()) // Ignoring navigation properties
                .ForMember(dest => dest.SubService, opt => opt.Ignore()); // Ignoring navigation properties

            // Mapping from ServiceSubService to ServiceSubServiceDto (if needed)
            CreateMap<ServiceSubService, ServiceSubServiceDto>();
        }
    }
}
