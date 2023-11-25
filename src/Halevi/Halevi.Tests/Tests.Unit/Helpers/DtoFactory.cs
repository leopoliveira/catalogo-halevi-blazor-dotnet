using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Application.DTOs.Product;
using Halevi.Core.Application.DTOs.ProductVariation;
using Halevi.Core.Domain.Entities;
using Halevi.Tests.Tests.Unit.Mappers;

namespace Halevi.Tests.Tests.Unit.Helpers
{
    internal static class DtoFactory
    {
        #region Category

        internal static CategoryReadDto MakeCategoryReadDto()
        {
            return new CategoryReadDto
            {
                Id = ConstantsFactory._categoryId,
                Name = "Category 1",
                Code = 1,
                Active = true
            };
        }

        internal static CategoryCreateDto MakeCategoryCreateDto()
        {
            return new CategoryCreateDto
            {
                Name = "Category 1",
                Code = 1,
                Active = true
            };
        }

        internal static CategoryUpdateDto MakeCategoryUpdateDto()
        {
            return new CategoryUpdateDto
            {
                Id = ConstantsFactory._categoryId,
                Name = "Category 1",
                Code = 1,
                Active = true
            };
        }

        #endregion

        #region Product

        internal static ProductReadDto MakeProductReadDto()
        {
            return new ProductReadDto
            {
                Id = ConstantsFactory._productId,
                CategoryId = ConstantsFactory._categoryId,
                CategoryName = "Category 1",
                Name = "Product 1",
                Description = "Description 1",
                Price = 20.50d,
                InStock = true,
                Code = 1,
                Active = true
            };
        }

        internal static ProductCreateDto MakeProductCreateDto()
        {
            return new ProductCreateDto
            {
                CategoryId = ConstantsFactory._categoryId,
                Name = "Product 1",
                Description = "Description 1",
                Price = 20.50d,
                InStock = true,
                Code = 1,
                Active = true
            };
        }

        internal static ProductUpdateDto MakeProductUpdateDto()
        {
            return new ProductUpdateDto
            {
                Id = ConstantsFactory._productId,
                CategoryId = ConstantsFactory._categoryId,
                Name = "Product 1",
                Description = "Description 1",
                Price = 20.50d,
                InStock = true,
                Code = 1,
                Active = true
            };
        }

        #endregion

        #region Variation

        internal static ProductVariationReadDto MakeVariationReadDto()
        {
            return new ProductVariationReadDto
            {
                Id = ConstantsFactory._variationId,
                ProductId = ConstantsFactory._productId,
                ProductName = "Product 1",
                Name = "Variation 1",
                Image = [],
                Code = 1,
                Active = true
            };
        }

        internal static ProductVariationCreateDto MakeVariationCreateDto()
        {
            return new ProductVariationCreateDto
            {
                ProductId = ConstantsFactory._productId,
                Name = "Variation 1",
                Image = [],
                Code = 1,
                Active = true
            };
        }

        internal static ProductVariationUpdateDto MakeVariationUpdateDto()
        {
            return new ProductVariationUpdateDto
            {
                Id = ConstantsFactory._variationId,
                ProductId = ConstantsFactory._productId,
                Name = "Variation 1",
                Image = [],
                Code = 1,
                Active = true
            };
        }

        #endregion
    }
}
