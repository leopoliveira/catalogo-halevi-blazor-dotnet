using FluentAssertions;

using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Application.Mappers;
using Halevi.Core.Domain.Entities;
using Halevi.Tests.Helpers;

namespace Halevi.Tests.Unit.Mappers
{
    public class CategoryMapperTest
    {
        [Fact]
        // Method_Scenario_Result
        public void ToEntity_CreateDtoToEntity_CategoryEntity()
        {
            // Arrange
            CategoryCreateDto dto = DtoFactory.MakeCategoryCreateDto();

            // Act
            Category entity = dto.ToEntity();

            // Assert
            entity
                .Should()
                .BeEquivalentTo(dto);
        }

        [Fact]
        public void ToEntity_NullCreateDtoToEntity_ThrowArgumentNullException()
        {
            // Arrange
            CategoryCreateDto dto = null;

            // Act
            Category entity = new();

            // Assert
            entity
                .Invoking(_ => dto.ToEntity())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToEntity_UpdateDtoToEntity_CategoryEntity()
        {
            // Arrange
            CategoryUpdateDto dto = DtoFactory.MakeCategoryUpdateDto();

            // Act
            Category entity = dto.ToEntity();

            // Assert
            entity
                .Should()
                .BeEquivalentTo(dto);
        }

        [Fact]
        public void ToEntity_NullUpdateDtoToEntity_ThrowArgumentNullException()
        {
            // Arrange
            CategoryUpdateDto dto = null;

            // Act
            Category entity = new();

            // Assert
            entity
                .Invoking(_ => dto.ToEntity())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void To
    }
}
