using Halevi.Core.Domain.Entities;
using System;

namespace Halevi.Tests.Helpers
{
    internal static class EntityFactory
    {
        #region Category

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

        internal static List<Category> MakeListOfCategory()
        {
            return new List<Category>
            {
                MakeCategory()
            };
        }

        #endregion

        #region Product

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

        internal static List<Product> MakeListOfProduct()
        {
            return new List<Product>
            {
                MakeProduct()
            };
        }

        #endregion

        #region Variation

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

        internal static List<ProductVariation> MakeListOfVariations()
        {
            return new List<ProductVariation>
            {
                MakeVariation()
            };
        }

        #endregion
    }
}
