using AutoMapper;
using HPS_backoffice.DTOs.Customer;
using HPS_backoffice.Models;

namespace HPS_backoffice.Automapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            // Mapping from CustomerDto to HpsCustomer
            CreateMap<CustomerDto, HpsCustomer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id during updates
                .ForMember(dest => dest.CustomersLandingPages, opt => opt.Ignore()) // Ignore navigation properties
                .ForMember(dest => dest.ExternalUsers, opt => opt.Ignore()) // Ignore navigation properties
                .ForMember(dest => dest.Transactions, opt => opt.Ignore()); // Ignore navigation properties

            // Mapping from HpsCustomer to CustomerDto (if needed)
            CreateMap<HpsCustomer, CustomerDto>();

            // Mapping from CustomerLandingDto to CustomersLandingPage
            CreateMap<CustomerLandingDto, CustomersLandingPage>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id for update scenarios
                .ForMember(dest => dest.HpsCustomer, opt => opt.Ignore()); // Ignore navigation property

            // Mapping from CustomersLandingPage to CustomerLandingDto
            CreateMap<CustomersLandingPage, CustomerLandingDto>();


            CreateMap<CustomerWithLandingPagesDto, HpsCustomer>()
            .ForMember(dest => dest.CustomersLandingPages, opt => opt.Ignore()) // Handle landing pages separately
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ?? true))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted ?? false));

            CreateMap<LandingPageDto, CustomersLandingPage>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ?? true))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted ?? false));
        }
    }

}
