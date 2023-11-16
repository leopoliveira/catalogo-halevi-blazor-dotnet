using Halevi.Core.Application.DTOs.Product;

namespace Halevi.Core.Application.DTOs.ProductVariation
{
    public record ProductVariationReadDto : ProductVariationBaseDto
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
