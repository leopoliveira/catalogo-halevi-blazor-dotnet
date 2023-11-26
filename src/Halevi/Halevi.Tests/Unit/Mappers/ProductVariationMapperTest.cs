namespace Halevi.Tests.Unit.Mappers
{
    public class ProductVariationVariationMapperTest
    {
        [Fact]
        // Method_Scenario_Result
        public void ToEntity_CreateDtoToEntity_ProductVariationEntity()
        {
            // Arrange
            ProductVariationCreateDto dto = DtoFactory.MakeVariationCreateDto();

            // Act
            ProductVariation entity = dto.ToEntity();

            // Assert
            entity
                .Should()
                .BeEquivalentTo(dto);
        }

        [Fact]
        public void ToEntity_NullCreateDtoToEntity_ThrowArgumentNullException()
        {
            // Arrange
            ProductVariationCreateDto dto = null;

            // Act
            ProductVariation entity = new();

            // Assert
            entity
                .Invoking(_ => dto.ToEntity())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToEntity_UpdateDtoToEntity_ProductVariationEntity()
        {
            // Arrange
            ProductVariationUpdateDto dto = DtoFactory.MakeVariationUpdateDto();

            // Act
            ProductVariation entity = dto.ToEntity();

            // Assert
            entity
                .Should()
                .BeEquivalentTo(dto);
        }

        [Fact]
        public void ToEntity_NullUpdateDtoToEntity_ThrowArgumentNullException()
        {
            // Arrange
            ProductVariationUpdateDto dto = null;

            // Act
            ProductVariation entity = new();

            // Assert
            entity
                .Invoking(_ => dto.ToEntity())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToReadDto_EntityToReadDto_ProductVariationReadDto()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            ProductVariationReadDto dto = entity.ToReadDto();

            // Assert
            dto
                .Should()
                .BeEquivalentTo(entity, config =>
                    config
                    .Excluding(entity => entity.Product)
                    .Excluding(entity => entity.CreatedAt));
        }

        [Fact]
        public void ToReadDto_NullEntity_ThrowArgumentNullException()
        {
            // Arrange
            ProductVariation entity = null;

            // Act
            ProductVariationReadDto dto = new();

            // Assert
            dto
                .Invoking(_ => entity.ToReadDto())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToUpdateDto_EntityToUpdateDto_ProductVariationUpdateDto()
        {
            // Arrange
            ProductVariation entity = EntityFactory.MakeVariation();

            // Act
            ProductVariationUpdateDto dto = entity.ToUpdateDto();

            // Assert
            dto
                .Should()
                .BeEquivalentTo(entity, config =>
                    config
                    .Excluding(entity => entity.Product)
                    .Excluding(entity => entity.CreatedAt));
        }

        [Fact]
        public void ToUpdateDto_NullEntity_ThrowArgumentNullException()
        {
            // Arrange
            ProductVariation entity = null;

            // Act
            ProductVariationUpdateDto dto = new();

            // Assert
            dto
                .Invoking(_ => entity.ToUpdateDto())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
