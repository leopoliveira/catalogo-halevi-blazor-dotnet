using Halevi.Core.Application.Helpers;
using Halevi.Core.Domain.Validations;

namespace Halevi.Tests.Unit.Validations
{
    public class ProductVariationVariationValidationTest
    {
        private readonly ProductVariationValidations _validationRules;

        public ProductVariationVariationValidationTest()
        {
            _validationRules = new ProductVariationValidations();
        }

        [Fact]
        // Method_Scenario_Result
        public void ProductVariationValidation_ValidProductVariation_ValidationOk()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ProductVariationValidation_EmptyProductVariationName_ValidationNotOk()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            entity.Name = string.Empty;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductVariationValidation_EmptyProductId_ValidationNotOk()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            entity.ProductId = Guid.Empty;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductVariationValidation_EmpyProductVariationCreatedAt_ValidationNotOk()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            entity.CreatedAt = DateOnly.MinValue;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductVariationValidation_InvalidProductVariationCode_ValidationNotOk()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            entity.Code = 0;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }
    }
}
