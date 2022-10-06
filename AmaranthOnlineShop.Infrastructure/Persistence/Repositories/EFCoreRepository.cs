using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Application.Extensions;
using AmaranthOnlineShop.Domain;
using AmaranthOnlineShop.Infrastructure.Persistence.Contexts;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AmaranthOnlineShop.Infrastructure.Persistence.Repositories
{
    public class EFCoreRepository : IRepository
    {
        private readonly AmaranthOnlineShopDbContext _context;
        private readonly IMapper _mapper;

        public EFCoreRepository(AmaranthOnlineShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new ValidationException($"There no object of type{typeof(TEntity)} with id {id}");
            }

            _context.Set<TEntity>().Remove(entity);

            return entity;
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdWithInclude<TEntity>(int id, Expression<Func<TEntity, object>> include) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().Include(include).FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<TEntity> IncludeProperties<TEntity>(
            params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities.Include(includeProperty);
            }

            return entities;
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest)
            where TEntity : BaseEntity
            where TDto : class
        {
            return await _context.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<List<TEntity>> GetRangeByIds<TEntity>(int[] ids) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllWithInclude<TEntity>(Expression<Func<TEntity, object>> include) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().Include(include).ToListAsync();
        }
    }
}
