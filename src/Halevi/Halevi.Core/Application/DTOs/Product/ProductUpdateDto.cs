namespace Halevi.Core.Application.DTOs.Product
{
    public record ProductUpdateDto : ProductCreateDto
    {
        public Guid Id { get; set; }
    }
}
