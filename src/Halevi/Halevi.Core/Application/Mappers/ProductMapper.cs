using Halevi.Core.Application.DTOs.Product;
using Halevi.Core.Domain.Entities;

namespace Halevi.Core.Application.Mappers
{
    public static class ProductMapper
    {
        public static Product ToEntity(this ProductCreateDto dto)
        {
            return new Product()
            {
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                InStock = dto.InStock,
                CategoryId = dto.CategoryId,
                Id = dto.Id,
                Active = dto.Active
            };
        }

        public static ProductReadDto ToReadDto(this Product product)
        {
            return new ProductReadDto()
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                InStock = product.InStock,
                CategoryId = product.Category.Id,
                CategoryName = product.Category.Name,
                Active = product.Active
            };
        }
        public static ProductCreateDto ToCreateDto(this Product product)
        {
            return new ProductCreateDto()
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                InStock = product.InStock,
                CategoryId = product.CategoryId,
                Active = product.Active
            };
        }
    }
}
