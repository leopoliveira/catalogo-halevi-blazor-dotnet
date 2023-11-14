﻿using System.Linq.Expressions;

using Halevi.Core.Domain.Entities.Base;
using Halevi.Core.Domain.Interfaces.Repositories.Base;
using Halevi.Core.Domain.Utils;
using Halevi.Infra.DbConfig;

using Microsoft.EntityFrameworkCore;

namespace Halevi.Infra.Implementations.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntitiy
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByAsync(Guid id)
        {
            return await _dbSet
                .Where(x => x.Id == id)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<TEntity> GetByAsync(int code)
        {
            return await _dbSet
                .Where(x => x.Code == code)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<TEntity>> GetByAsync(DateOnly createdDate, Pagination pagination)
        {
            return await _dbSet
                .Where(x => createdDate.CompareTo(x.CreatedAt) == 0)
                .AsNoTracking()
                .Skip(NumberOfItemsToSkip(pagination))
                .Take(NumberOfItemsToTake(pagination))
                .ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> filter, Pagination pagination)
        {
            return await _dbSet
                .Where(filter)
                .AsNoTracking()
                .Skip(NumberOfItemsToSkip(pagination))
                .Take(NumberOfItemsToTake(pagination))
                .ToListAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
        public async Task<bool> Exists(int code)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(x => x.Code == code);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .CountAsync();
        }
        public async Task<int> CountWhereAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet
                .Where(filter)
                .AsNoTracking()
                .CountAsync();
        }


        public async Task<int> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity.Code;
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Property(x => x.Code).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        private static int NumberOfItemsToSkip(Pagination pagination)
        {
            return (pagination.ActualPage - 1) * pagination.PageOffset;
        }

        private static int NumberOfItemsToTake(Pagination pagination)
        {
            return pagination.PageOffset;
        }
    }
}