using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Common.Intefaces
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
    }
}
