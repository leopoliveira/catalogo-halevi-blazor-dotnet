namespace Halevi.Core.Application.DTOs.Category
{
    public record CategoryUpdateDto : CategoryCreateDto
    {
        public Guid Id { get; set; }
    }
}
