using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;

namespace AmaranthOnlineShop.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;

        Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] include)
            where TEntity : BaseEntity;

        Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;
        Task SaveChangesAsync();
        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;
        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity where TDto : class;
    }
}
