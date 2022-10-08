using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text;

namespace AmaranthOnlineShop.Application.Extensions
{
    public static partial class QueryableExtensions
    {
        public static async Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(
            this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper)
            where TEntity : BaseEntity
            where TDto : class
        {
            query = query.ApplyFilters(pagedRequest);

            var total = await query.CountAsync();

            var sortedQuery = query.Sort(pagedRequest);

            query = sortedQuery.Paginate(pagedRequest);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            var listResult = await projectionResult.ToListAsync();

            return new PaginatedResult<TDto>()
            {
                Items = listResult,
                PageSize = pagedRequest.PageSize,
                PageIndex = pagedRequest.PageIndex,
                Total = total,
            };
        }

        private static IQueryable<T> Paginate<T>(this IOrderedQueryable<T> query, PagedRequest pagedRequest)
        {
            var entities = query.Skip((pagedRequest.PageIndex - 1) * pagedRequest.PageSize).Take(pagedRequest.PageSize);
            return entities;
        }
        private static IOrderedQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            return query.OrderBy(pagedRequest.SortingColumnName + " " + pagedRequest.SortDirection);
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var predicate = new StringBuilder();
            var requestFilters = pagedRequest.RequestFilters;
            if (requestFilters == null)
            {
                return query;
            }

            for (int i = 0; i < requestFilters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {requestFilters.LogicalOperator} ");
                }

                if (requestFilters.Filters[i].Path is "Price" or "Id")
                    predicate.Append(requestFilters.Filters[i].Path + requestFilters.Filters[i].Value);
                else
                    predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Contains)}(@{i})");
            }

            if (requestFilters.Filters.Any())
            {
                var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

                query = query.Where(predicate.ToString(), propertyValues);
            }

            return query;
        }
    }
}
