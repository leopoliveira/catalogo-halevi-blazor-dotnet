using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories.Base;

namespace Halevi.Core.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// Gets all available categories.
        /// </summary>
        /// <returns>All available categories.</returns>
        public Task<IEnumerable<Category>> GetAllAsync();
    }
}
