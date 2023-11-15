using Halevi.Core.Application.DTOs.Base;

namespace Halevi.Core.Application.DTOs.Product
{
    public record ProductBaseDto : BaseDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public bool InStock { get; set; }
    }
}
