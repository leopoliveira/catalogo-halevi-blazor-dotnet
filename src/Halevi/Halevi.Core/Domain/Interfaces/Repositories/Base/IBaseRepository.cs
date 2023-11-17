using System.Linq.Expressions;

using Halevi.Core.Domain.Entities.Base;
using Halevi.Core.Domain.Utils;

namespace Halevi.Core.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntitiy
    {
        Task<TEntity> GetByAsync(Guid id);
        Task<TEntity> GetByAsync(int code);
        Task<IEnumerable<TEntity>> GetByAsync(DateOnly createdDate, Pagination pagination);
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> filter, Pagination pagination);

        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(int code);

        Task<int> CountAsync();
        Task<int> CountWhereAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
