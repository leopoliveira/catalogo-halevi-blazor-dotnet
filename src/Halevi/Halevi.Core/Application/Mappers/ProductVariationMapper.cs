using Halevi.Core.Application.DTOs.ProductVariation;
using Halevi.Core.Domain.Entities;

namespace Halevi.Core.Application.Mappers
{
    public static class ProductVariationMapper
    {
        public static ProductVariation ToEntity(this ProductVariationCreateDto dto)
        {
            return new ProductVariation()
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Image = dto.Image,
                ProductId = dto.ProductId,
                Active = dto.Active
            };
        }

        public static ProductVariationReadDto ToReadDto(this ProductVariation productVariation)
        {
            return new ProductVariationReadDto()
            {
                Id = productVariation.Id,
                Code = productVariation.Code,
                Name = productVariation.Name,
                Image = productVariation.Image,
                ProductId = productVariation.Product.Id,
                ProductName = productVariation.Product.Name,
                Active = productVariation.Active
            };
        }

        public static ProductVariationCreateDto ToCreateDto(this ProductVariation productVariation)
        {
            return new ProductVariationCreateDto()
            {
                Id = productVariation.Id,
                Code = productVariation.Code,
                Name = productVariation.Name,
                Image = productVariation.Image,
                ProductId = productVariation.ProductId,
                Active = productVariation.Active
            };
        }
    }
}
