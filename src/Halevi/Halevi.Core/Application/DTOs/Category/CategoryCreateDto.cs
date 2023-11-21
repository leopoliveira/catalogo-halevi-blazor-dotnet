using Halevi.Core.Application.DTOs.Base;

namespace Halevi.Core.Application.DTOs.Category
{
    public record CategoryCreateDto : BaseDto
    {
        public string Name { get; set; }
    }
}
