using Halevi.Core.Application.DTOs.Base;

namespace Halevi.Core.Application.DTOs.Category
{
    public record CategoryDto : BaseDto
    {
        public string Name { get; set; }
    }
}
