using Halevi.Core.Application.DTOs.Base;

namespace Halevi.Core.Application.DTOs.Category
{
    public record CategoryReadDto : BaseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
