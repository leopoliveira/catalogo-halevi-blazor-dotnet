namespace Halevi.Core.Application.DTOs.Product
{
    public record ProductCreateDto : ProductBaseDto
    {
        public Guid CategoryId { get; set; }
    }
}
