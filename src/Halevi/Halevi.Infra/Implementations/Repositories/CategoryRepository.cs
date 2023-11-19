using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Infra.DbConfig;
using Halevi.Infra.Implementations.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace Halevi.Infra.Implementations.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Gets all available categories.
        /// </summary>
        /// <returns>All available categories.</returns>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.CATEGORY
                .AsNoTracking()
                .Where(x => x.Active)
                .ToListAsync();
        }
    }
}
