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
        public async Task<IEnumerable<TEntity>> GetAllAsync(Pagination pagination)
        {
            return await _dbSet
                .AsNoTracking()
                .Skip((pagination.ActualPage - 1) * pagination.PageOffset)
                .Take(pagination.PageOffset)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
        public async Task<bool> ExistsAsync(int code)
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
            entity.Active = false;

            await UpdateAsync(entity);
        }
    }
}
