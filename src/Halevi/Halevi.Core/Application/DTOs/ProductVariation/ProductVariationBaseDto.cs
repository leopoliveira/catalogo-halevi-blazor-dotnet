using Halevi.Core.Application.DTOs.Base;

namespace Halevi.Core.Application.DTOs.ProductVariation
{
    public record ProductVariationBaseDto : BaseDto
    {
        public string Name { get; set; }

        public bool[]? Image { get; set; }
    }
}
