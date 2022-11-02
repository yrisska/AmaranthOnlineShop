using System.Linq.Expressions;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AmaranthOnlineShop.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;

        Task<TEntity> GetByIdWithInclude<TEntity>(int id, Expression<Func<TEntity, object>> include)
            where TEntity : BaseEntity;

        Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;
        Task<List<TEntity>> GetAllWithInclude<TEntity>(Expression<Func<TEntity, object>> include) where TEntity : BaseEntity;
        Task<List<TEntity>> GetRangeByPredicateWithInclude<TEntity>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include) where TEntity : BaseEntity;
        Task SaveChangesAsync();
        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void AddRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : BaseEntity;
        Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;

        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest)
            where TEntity : BaseEntity where TDto : class;

        Task<List<TEntity>> GetRangeByIds<TEntity>(int[] ids) where TEntity : BaseEntity;
    }
}
