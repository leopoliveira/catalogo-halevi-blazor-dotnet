using Halevi.Core.Domain.Entities.Base;

namespace Halevi.Core.Domain.Entities
{
    public class Product : BaseEntitiy
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public double Price { get; set; }

        public bool InStock { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ProductVariation> ProductVariations { get; } = new List<ProductVariation>();
    }
}
