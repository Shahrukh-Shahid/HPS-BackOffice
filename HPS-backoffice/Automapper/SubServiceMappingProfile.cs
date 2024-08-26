using AutoMapper;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.Models;

namespace HPS_backoffice.Automapper
{
    public class SubServiceMappingProfile : Profile
    {
        public SubServiceMappingProfile()
        {
            // Mapping from SubServiceDto to SubService
            CreateMap<SubServiceDto, SubService>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id for updates
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted ?? false)) // Handle IsDeleted default
                .ForMember(dest => dest.ClientSubServices, opt => opt.Ignore()) // Ignoring collection mappings
                .ForMember(dest => dest.ServiceSubServices, opt => opt.Ignore()); // Ignoring collection mappings

            // Mapping from SubService to SubServiceDto (if needed)
            CreateMap<SubService, SubServiceDto>();
        }
    }
}
