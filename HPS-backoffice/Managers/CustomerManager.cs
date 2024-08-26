using AutoMapper;
using HPS_backoffice.DTOs.Common;
using HPS_backoffice.DTOs.Customer;
using HPS_backoffice.DTOs.Service;
using HPS_backoffice.Interfaces;
using HPS_backoffice.Models;
using HPS_backoffice.Utilities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HPS_backoffice.Managers
{
    public class CustomerManager : ICustomer
    {
        private readonly HPSContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerManager(IMapper mapper, HPSContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<Response> CreateCustomer(CustomerDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (dto != null)
            {
                var newCustomer = _mapper.Map<HpsCustomer>(dto);
                newCustomer.IsDeleted = false;
                newCustomer.IsActive = true;

                await _dbContext.HpsCustomers.AddAsync(newCustomer);
                await _dbContext.SaveChangesAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;
            }
            else
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
            }

            return returnVal;
        }

        public async Task<Response> UpdateCustomer(CustomerDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (!dto.Id.HasValue)
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
                return returnVal;
            }

            var customer = await _dbContext.HpsCustomers
                                .Where(x => x.Id == dto.Id)
                                .FirstOrDefaultAsync();

            if (customer == null)
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
                return returnVal;
            }

            customer.CustomerName = dto.CustomerName;
            customer.IsDeleted = dto.IsDeleted;
            customer.IsActive = dto.IsActive;
            customer.ModifiedBy = null;
            customer.ModifiedOn = DateTime.Now;
            customer.Description = dto.Description;

            await _dbContext.SaveChangesAsync();


            returnVal.StatusCode = 200;
            returnVal.Message = Constants.SuccessMessage;

            return returnVal;
        }

        public async Task<Response> AddCustomerLandingPage(CustomerLandingDto dto)
        {
            Response returnVal = new Response(200, string.Empty, null);

            if (!dto.HpsCustomerId.HasValue)
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
                return returnVal;
            }

            var existingPages = await _dbContext.CustomersLandingPages
                                       .Where(x => x.HpsCustomerId == dto.HpsCustomerId)
                                       .FirstOrDefaultAsync();

            if (existingPages == null)
            {
                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
            }


            return returnVal;
        }

        public async Task<Response> CreateCustomerWithLandingPage(CustomerWithLandingPagesDto dto)
        {

            Response returnVal = new Response(200, string.Empty, null);

            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Map and add customer
                var customer = _mapper.Map<HpsCustomer>(dto);
                await _dbContext.HpsCustomers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();

                // Validate and add landing pages
                var existingLandingPages = await _dbContext.CustomersLandingPages
                    .Where(lp => lp.HpsCustomerId == customer.Id && lp.IsActive == true)
                    .ToListAsync();

                if (existingLandingPages.Count >= 2)
                {
                    throw new Exception("Each customer can only have two landing pages.");
                }

                // Add portal landing page
                var portalLandingPage = _mapper.Map<CustomersLandingPage>(dto.PortalLandingPage);
                portalLandingPage.IsPortal = true;
                portalLandingPage.HpsCustomerId = customer.Id;

                // Add non-portal landing page
                var nonPortalLandingPage = _mapper.Map<CustomersLandingPage>(dto.NonPortalLandingPage);
                nonPortalLandingPage.IsPortal = false;
                nonPortalLandingPage.HpsCustomerId = customer.Id;

                // Save to database
                await _dbContext.CustomersLandingPages.AddRangeAsync(portalLandingPage, nonPortalLandingPage);
                await _dbContext.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                returnVal.StatusCode = 200;
                returnVal.Message = Constants.SuccessMessage;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            return returnVal;
        }

        public async Task<Response> UpdateLandingPage(LandingPageUpdateDto dto)
        {

            Response returnVal = new Response(200, string.Empty, null);

            if (dto == null) { throw new ArgumentNullException(); }

            if (!dto.Id.HasValue && !dto.CustomerId.HasValue)
            {
                throw new Exception("Invalid request");
            }

            var query = _dbContext.CustomersLandingPages.AsQueryable();

            if (dto.Id.HasValue && !dto.CustomerId.HasValue)
            {
                query = query.Where(x => x.Id == dto.Id.Value);
            }

            if (dto.CustomerId.HasValue)
            {
                query = query.Where(x => x.HpsCustomerId == dto.CustomerId.Value);
            }

            var pages = await query.Where(x=> x.IsActive == true && x.IsDeleted == false).ToListAsync();

            if(pages == null)
            {

                returnVal.StatusCode = 400;
                returnVal.Message = Constants.FailureMessage;
                return returnVal;
            }

            var portalPage = pages.FirstOrDefault(x => x.IsPortal == true);
            var nonPortalPage = pages.FirstOrDefault(x => x.IsPortal == false);

            // Begin transaction
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Update or insert portal landing page
                if (portalPage != null)
                {
                    portalPage.FailureUrl = dto.PortalLandingPage.FailureUrl;
                    portalPage.SuccessUrl = dto.PortalLandingPage.SuccessUrl;
                    portalPage.CancelUrl = dto.PortalLandingPage.CancelUrl;
                    portalPage.IsActive = dto.PortalLandingPage.IsActive;
                    portalPage.IsDeleted = dto.PortalLandingPage.IsDeleted;
                }
                else
                {
                    var newPortalPage = new CustomersLandingPage
                    {
                        HpsCustomerId = dto.CustomerId,
                        IsPortal = true,
                        FailureUrl = dto.PortalLandingPage.FailureUrl,
                        SuccessUrl = dto.PortalLandingPage.SuccessUrl,
                        CancelUrl = dto.PortalLandingPage.CancelUrl,
                        IsActive = dto.PortalLandingPage.IsActive,
                        IsDeleted = dto.PortalLandingPage.IsDeleted
                         
                    };
                    _dbContext.CustomersLandingPages.Add(newPortalPage);
                }

                // Update or insert non-portal landing page
                if (nonPortalPage != null)
                {
                    nonPortalPage.FailureUrl = dto.NonPortalLandingPage.FailureUrl;
                    nonPortalPage.SuccessUrl = dto.NonPortalLandingPage.SuccessUrl;
                    nonPortalPage.CancelUrl = dto.NonPortalLandingPage.CancelUrl;
                    nonPortalPage.IsActive = dto.NonPortalLandingPage.IsActive;
                    nonPortalPage.IsDeleted = dto.NonPortalLandingPage.IsDeleted;
                }
                else
                {
                    var newNonPortalPage = new CustomersLandingPage
                    {
                        HpsCustomerId = dto.CustomerId,
                        IsPortal = false,
                        FailureUrl = dto.NonPortalLandingPage.FailureUrl,
                        SuccessUrl = dto.NonPortalLandingPage.SuccessUrl,
                        CancelUrl = dto.NonPortalLandingPage.CancelUrl,
                        IsActive = dto.NonPortalLandingPage.IsActive,
                        IsDeleted = dto.NonPortalLandingPage.IsDeleted
                    };
                    _dbContext.CustomersLandingPages.Add(newNonPortalPage);
                }

                // Save changes
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // Rollback transaction in case of failure
                await transaction.RollbackAsync();
                throw new Exception("Error occurred while updating landing pages", ex);
            }

            return returnVal;

        }

        public async Task<Response> GetCustomers(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            IQueryable<HpsCustomer> query = _dbContext.HpsCustomers.AsQueryable();
            // Apply filters if provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            // Execute the query and select the required fields
            List<CustomerDto> customerList = await query
                                                   .Select(customer => new CustomerDto
                                                   {
                                                       Id = customer.Id,
                                                       CustomerName = customer.CustomerName,
                                                       Description = customer.Description,
                                                       RegistrationDate = customer.RegistrationDate,
                                                       ModifiedOn = customer.ModifiedOn,
                                                       ModifiedBy = customer.ModifiedBy,
                                                       IsActive = customer.IsActive
                                                   })
                                                   .ToListAsync();

            returnVal.Data = customerList.Any() ? customerList : null;
            returnVal.StatusCode = 200;
            returnVal.Message = customerList.Any() ? Constants.SuccessMessage : Constants.RecordNotFound;

            return returnVal;
        }

        public async Task<Response> GetCustomersWithLandingPage(SearchFilters? filters)
        {
            Response returnVal = new Response(200, string.Empty, null);

            IQueryable<CustomerWithLandingPagesDto> query = from c in _dbContext.HpsCustomers
                                                            join clp in _dbContext.CustomersLandingPages on c.Id equals clp.HpsCustomerId into landingPages
                                                            from lp in landingPages.DefaultIfEmpty()
                                                            //where (filters == null || (filters.CustomerId == null || c.Id == filters.CustomerId))
                                                            select new CustomerWithLandingPagesDto
                                                            {
                                                                Id = c.Id,
                                                                CustomerName = c.CustomerName,
                                                                Description = c.Description,
                                                                SecretKey = c.SecretKey,
                                                                IncomingRoute = c.IncomingRoute,
                                                                OutgoingRoute = c.OutgoingRoute,
                                                                RegistrationDate = c.RegistrationDate,
                                                                ModifiedBy = c.ModifiedBy,
                                                                ModifiedOn = c.ModifiedOn,
                                                                IsActive = c.IsActive,
                                                                IsDeleted = c.IsDeleted,
                                                                // Landing pages
                                                                PortalLandingPage = lp != null && lp.IsPortal == true ? new LandingPageDto
                                                                {
                                                                    FailureUrl = lp.FailureUrl,
                                                                    SuccessUrl = lp.SuccessUrl,
                                                                    CancelUrl = lp.CancelUrl,
                                                                    IsActive = lp.IsActive,
                                                                    IsDeleted = lp.IsDeleted
                                                                } : null,
                                                                NonPortalLandingPage = lp != null && lp.IsPortal == false ? new LandingPageDto
                                                                {
                                                                    FailureUrl = lp.FailureUrl,
                                                                    SuccessUrl = lp.SuccessUrl,
                                                                    CancelUrl = lp.CancelUrl,
                                                                    IsActive = lp.IsActive,
                                                                    IsDeleted = lp.IsDeleted
                                                                } : null
                                                            };
            // Apply filters if provided
            if (filters != null)
                query = QueryHelper.ApplyFilters(query, filters);
            else
                query = query.Where(x => x.IsActive == true && x.IsDeleted == false);

            var result = await query.ToListAsync();

            returnVal.Data = result.Any() ? result : null;
            returnVal.StatusCode = 200;
            returnVal.Message = result.Any() ? Constants.SuccessMessage : Constants.RecordNotFound;

            return returnVal;
        }
    }
}
