using Halevi.Core.Application.Helpers;
using Halevi.Core.Domain.Validations;

namespace Halevi.Tests.Unit.Validations
{
    public class CategoryValidationTest
    {
        private readonly CategoryValidations _validationRules;

        public CategoryValidationTest()
        {
            _validationRules = new CategoryValidations();
        }

        [Fact]
        // Method_Scenario_Result
        public void CategoryValidation_ValidCategory_ValidationOk()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeTrue();
        }

        [Fact]
        public void CategoryValidation_EmptyCategoryName_ValidationNotOk()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            entity.Name = string.Empty;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void CategoryValidation_NullCategoryName_ValidationNotOk()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            entity.Name = null;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void CategoryValidation_LongCategoryName_ValidationNotOk()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            entity.Name = new string('a', ValidationConsts.MAX_SHORT_STRING_LENGTH + 1);
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void CategoryValidation_EmpyCategoryCreatedAt_ValidationNotOk()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            entity.CreatedAt = DateOnly.MinValue;
            bool validationResult = _validationRules.Validate(entity).IsValid;

            // Assert
            validationResult
                .Should()
                .BeFalse();
        }

        [Fact]
        public void CategoryValidation_InvalidCategoryCode_ValidationNotOk()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

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
