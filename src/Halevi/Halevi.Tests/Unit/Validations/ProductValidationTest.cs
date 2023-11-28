using Halevi.Core.Application.Helpers;
using Halevi.Core.Domain.Validations;

namespace Halevi.Tests.Unit.Validations
{
    public class ProductValidationTest
    {
        private readonly ProductValidations _validationRules = new();

        [Fact]
        // Method_Scenario_Result
        public void ProductValidation_ValidProduct_ValidationOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ProductValidation_EmptyProductName_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.Name = string.Empty;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_NullProductName_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.Name = null;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_LongProductName_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.Name = new string('a', ValidationConsts.MAX_SHORT_STRING_LENGTH + 1);
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_LongProductDescription_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.Description = new string('a', ValidationConsts.MAX_LONG_TEXT_LENGTH + 1);
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_InvalidProductPrice_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.Price = 0d;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_EmptyCategoryId_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.CategoryId = Guid.Empty;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_EmpyProductCreatedAt_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            entity.CreatedAt = DateOnly.MinValue;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ProductValidation_InvalidProductCode_ValidationNotOk()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

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
