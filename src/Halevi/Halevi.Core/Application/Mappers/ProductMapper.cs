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
                Code = dto.Code.Value,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                InStock = dto.InStock,
                CategoryId = dto.CategoryId,
                Active = dto.Active
            };
        }

        public static Product ToEntity(this ProductUpdateDto dto)
        {
            return new Product()
            {
                Id = dto.Id,
                Code = dto.Code.Value,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                InStock = dto.InStock,
                CategoryId = dto.CategoryId,
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

        public static ProductUpdateDto ToUpdateDto(this Product product)
        {
            return new ProductUpdateDto()
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
