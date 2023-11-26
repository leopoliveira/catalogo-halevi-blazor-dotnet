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
        public void ToReadDto_EntityToReadDto_CategoryReadDto()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            CategoryReadDto dto = entity.ToReadDto();

            // Assert
            dto
                .Should()
                .BeEquivalentTo(entity, config =>
                    config
                    .Excluding(entity => entity.Products)
                    .Excluding(entity => entity.CreatedAt));
        }

        [Fact]
        public void ToReadDto_NullEntity_ThrowArgumentNullException()
        {
            // Arrange
            Category entity = null;

            // Act
            CategoryReadDto dto = new();

            // Assert
            dto
                .Invoking(_ => entity.ToReadDto())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToUpdateDto_EntityToUpdateDto_CategoryUpdateDto()
        {
            // Arrange
            Category entity = EntityFactory.MakeCategory();

            // Act
            CategoryUpdateDto dto = entity.ToUpdateDto();

            // Assert
            dto
                .Should()
                .BeEquivalentTo(entity, config =>
                    config
                    .Excluding(entity => entity.Products)
                    .Excluding(entity => entity.CreatedAt));
        }

        [Fact]
        public void ToUpdateDto_NullEntity_ThrowArgumentNullException()
        {
            // Arrange
            Category entity = null;

            // Act
            CategoryUpdateDto dto = new();

            // Assert
            dto
                .Invoking(_ => entity.ToUpdateDto())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
