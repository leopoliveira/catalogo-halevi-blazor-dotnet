using Halevi.Core.Domain.Entities.Base;
using Halevi.Core.Domain.Utils;

namespace Halevi.Core.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntitiy
    {
        Task<TEntity> GetByAsync(Guid id);
        Task<TEntity> GetByAsync(int code);
        Task<IEnumerable<TEntity>> GetByAsync(DateTime createdDate, Pagination pagination);
        Task<IEnumerable<TEntity>> GetWhereAsync(Func<TEntity, bool> filter, Pagination pagination);

        Task<int> CountAsync();
        Task<int> CountWhereAsync(Func<TEntity, bool> filter);

        Task<int> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);
        Task DeleteAsync(int code);
    }
}
