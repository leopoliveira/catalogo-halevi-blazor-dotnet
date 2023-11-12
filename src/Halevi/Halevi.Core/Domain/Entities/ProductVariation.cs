using Halevi.Core.Domain.Entities.Base;

namespace Halevi.Core.Domain.Entities
{
    public class ProductVariation : BaseEntitiy
    {
        public string Name { get; set; } = null!;

        public bool[]? Image { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
