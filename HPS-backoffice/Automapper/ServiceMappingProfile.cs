using AutoMapper;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.Models;


namespace HPS_backoffice.Automapper
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            // Mapping from ServiceDto to Service
            CreateMap<ServiceDto, Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.HasValue ? src.Id.Value : Guid.NewGuid())) // Handle Id assignment
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted ?? false)) // Default IsDeleted if null
                .ForMember(dest => dest.VendorId, opt => opt.Ignore()) // VendorId is not present in the DTO
                .ForMember(dest => dest.ServiceSubServices, opt => opt.Ignore()) // Ignoring collection mappings
                .ForMember(dest => dest.Transactions, opt => opt.Ignore()) // Ignoring collection mappings
                .ForMember(dest => dest.Vendor, opt => opt.Ignore()); // Ignoring navigation property

            // Mapping from Service to ServiceDto (if needed)
            CreateMap<Service, ServiceDto>();
        }
    }
}
