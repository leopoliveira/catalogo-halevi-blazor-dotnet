using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Infra.DbConfig;
using Halevi.Infra.Implementations.Repositories.Base;

namespace Halevi.Infra.Implementations.Repositories
{
    public class ProductVariationRepository : BaseRepository<ProductVariation>, IProductVariationRepository
    {
        public ProductVariationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
