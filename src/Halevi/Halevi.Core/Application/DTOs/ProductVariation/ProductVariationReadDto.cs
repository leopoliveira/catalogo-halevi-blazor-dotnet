using Halevi.Core.Application.DTOs.Product;

namespace Halevi.Core.Application.DTOs.ProductVariation
{
    public record ProductVariationReadDto : ProductVariationBaseDto
    {
        public ProductReadDto Product { get; set; }
    }
}
