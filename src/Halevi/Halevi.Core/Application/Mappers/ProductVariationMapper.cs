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
                Code = dto.Code.Value,
                Name = dto.Name,
                Image = dto.Image,
                ProductId = dto.ProductId,
                Active = dto.Active
            };
        }

        public static ProductVariation ToEntity(this ProductVariationUpdateDto dto)
        {
            return new ProductVariation()
            {
                Id = dto.Id,
                Code = dto.Code.Value,
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

        public static ProductVariationUpdateDto ToUpdateDto(this ProductVariation productVariation)
        {
            return new ProductVariationUpdateDto()
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
