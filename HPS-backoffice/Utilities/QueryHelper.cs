using HPS_backoffice.DTOs.Common;
using Microsoft.EntityFrameworkCore;

namespace HPS_backoffice.Utilities
{
    public static class QueryHelper
    {
        public static IQueryable<T> ApplyFilters<T>(IQueryable<T> query, SearchFilters filters) where T : class
        {
            // Filtering by Id
            if (filters.Id.HasValue)
            {
                query = query.Where(x => EF.Property<Guid>(x, "Id") == filters.Id.Value);
            }

            // Filtering by ServiceId if applicable
            if (typeof(T).GetProperty("ServiceId") != null && filters.ServiceId.HasValue)
            {
                query = query.Where(x => EF.Property<Guid?>(x, "ServiceId") == filters.ServiceId.Value);
            }

            // Filtering by SubServiceId if applicable
            if (typeof(T).GetProperty("SubServiceId") != null && filters.SubServiceId.HasValue)
            {
                query = query.Where(x => EF.Property<Guid?>(x, "SubServiceId") == filters.SubServiceId.Value);
            }

            // Keyword or text-based search (assumes the entity has a "Name" or similar property)
            if (!string.IsNullOrEmpty(filters.SearchTerm))
            {
                query = query.Where(x => EF.Functions.Like(EF.Property<string>(x, "Name"), $"%{filters.SearchTerm}%"));
            }

            // Filtering by CreatedDate and ModifiedDate
            if (filters.CreatedDate.HasValue)
            {
                query = query.Where(x => EF.Property<DateTime>(x, "CreatedOn") == filters.CreatedDate.Value);
            }

            if (filters.ModifiedDate.HasValue)
            {
                query = query.Where(x => EF.Property<DateTime>(x, "ModifiedOn") == filters.ModifiedDate.Value);
            }

            // Filtering by CreatedBy and ModifiedBy
            if (filters.CreatedBy.HasValue)
            {
                query = query.Where(x => EF.Property<Guid>(x, "CreatedBy") == filters.CreatedBy.Value);
            }

            if (filters.ModifiedBy.HasValue)
            {
                query = query.Where(x => EF.Property<Guid>(x, "ModifiedBy") == filters.ModifiedBy.Value);
            }

            // Filtering by IsActive
            if (filters.IsActive.HasValue)
            {
                query = query.Where(x => EF.Property<bool>(x, "IsActive") == filters.IsActive.Value);
            }

            // Sorting
            if (!string.IsNullOrEmpty(filters.SortBy))
            {
                query = filters.SortDescending
                    ? query.OrderByDescending(x => EF.Property<object>(x, filters.SortBy))
                    : query.OrderBy(x => EF.Property<object>(x, filters.SortBy));
            }

            // Pagination
            query = query.Skip((filters.PageNumber - 1) * filters.PageSize).Take(filters.PageSize);

            return query;
        }
    }

}
