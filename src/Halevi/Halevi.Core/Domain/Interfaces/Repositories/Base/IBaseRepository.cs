using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Entities.Base;
using Halevi.Core.Domain.Utils;

namespace Halevi.Core.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntitiy
    {
        Task<TEntity> GetByAsync(Guid id);

        Task<TEntity> GetByAsync(int code);

        Task<IEnumerable<TEntity>> GetAllAsync(Pagination pagination);

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsAsync(int code);

        Task<int> CountAsync();

        Task<int> CreateAsync(TEntity entity);

        int GetLastCode();

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
