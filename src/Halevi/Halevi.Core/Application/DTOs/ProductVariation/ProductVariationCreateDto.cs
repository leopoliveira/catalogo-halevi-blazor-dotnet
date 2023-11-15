namespace Halevi.Core.Application.DTOs.ProductVariation
{
    public record ProductVariationCreateDto : ProductVariationBaseDto
    {
        public Guid ProductId { get; set; }
    }
}
