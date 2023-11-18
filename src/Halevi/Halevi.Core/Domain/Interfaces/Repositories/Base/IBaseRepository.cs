using Halevi.Core.Domain.Entities.Base;

namespace Halevi.Core.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntitiy
    {
        Task<TEntity> GetByAsync(Guid id);
        Task<TEntity> GetByAsync(int code);

        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(int code);

        Task<int> CountAsync();

        Task<int> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
