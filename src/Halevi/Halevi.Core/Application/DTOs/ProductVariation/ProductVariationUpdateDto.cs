namespace Halevi.Core.Application.DTOs.ProductVariation
{
    public record ProductVariationUpdateDto : ProductVariationCreateDto
    {
        public Guid Id { get; set; }
    }
}
