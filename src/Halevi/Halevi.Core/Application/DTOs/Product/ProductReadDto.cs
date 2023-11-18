namespace Halevi.Core.Application.DTOs.Product
{
    public record ProductReadDto : ProductBaseDto
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }
    };
}
