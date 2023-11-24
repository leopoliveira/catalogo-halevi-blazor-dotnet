using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories.Base;

namespace Halevi.Core.Domain.Interfaces.Repositories
{
    public interface IProductVariationRepository : IBaseRepository<ProductVariation>
    {
        /// <summary>
        /// Get the entities by the given Product Code.
        /// </summary>
        /// <param name="productCode">The Product code.</param>
        /// <returns>The list of entities converted to list of Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<IEnumerable<ProductVariation>> GetByProduct(int productCode);

        /// <summary>
        /// Get the entities by the given Product Id.
        /// </summary>
        /// <param name="productId">The Product id.</param>
        /// <returns>The list of entities converted to list of Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<IEnumerable<ProductVariation>> GetByProduct(Guid productId);
    }
}
