using Halevi.Core.Domain.Entities;
using System;

namespace Halevi.Tests.Helpers
{
    internal static class EntityFactory
    {
        internal static Category MakeCategory()
        {
            return new Category
            {
                Name = "Category 1",
                Id = ConstantsFactory._categoryId,
                Code = 1,
                CreatedAt = ConstantsFactory._dateTime,
                Active = true
            };
        }

        internal static Product MakeProduct()
        {
            return new Product
            {
                Name = "Product 1",
                Description = "Description 1",
                Price = 20.50d,
                InStock = true,
                CategoryId = ConstantsFactory._categoryId,
                Id = ConstantsFactory._productId,
                Code = 1,
                CreatedAt = ConstantsFactory._dateTime,
                Active = true,
                Category = MakeCategory()
            };
        }

        internal static ProductVariation MakeVariation()
        {
            return new ProductVariation
            {
                Name = "Variation 1",
                Image = [],
                ProductId = ConstantsFactory._productId,
                Id = ConstantsFactory._variationId,
                Code = 1,
                CreatedAt = ConstantsFactory._dateTime,
                Active = true,
                Product = MakeProduct()
            };
        }
    }
}
