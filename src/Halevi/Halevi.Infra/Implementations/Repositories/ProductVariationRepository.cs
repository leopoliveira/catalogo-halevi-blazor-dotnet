using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Infra.DbConfig;
using Halevi.Infra.Implementations.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace Halevi.Infra.Implementations.Repositories
{
    public class ProductVariationRepository : BaseRepository<ProductVariation>, IProductVariationRepository
    {
        private readonly AppDbContext _context;

        public ProductVariationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Get the entities by the given Product Code.
        /// </summary>
        /// <param name="productCode">The Product code.</param>
        /// <returns>The list of entities converted to list of Dto.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<ProductVariation>> GetByProduct(int productCode)
        {
            return await _context
                .PRODUCTVARIATION
                .AsNoTracking()
                .Where(x => x.Product.Code == productCode)
                .ToListAsync();
        }

        /// <summary>
        /// Get the entities by the given Product Id.
        /// </summary>
        /// <param name="productId">The Product id.</param>
        /// <returns>The list of entities converted to list of Dto.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<ProductVariation>> GetByProduct(Guid productId)
        {
            return await _context
                .PRODUCTVARIATION
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
    }
}
