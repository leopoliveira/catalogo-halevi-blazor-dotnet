namespace Halevi.Tests.Unit.Mappers
{
    public class ProductMapperTest
    {
        [Fact]
        // Method_Scenario_Result
        public void ToEntity_CreateDtoToEntity_ProductEntity()
        {
            // Arrange
            ProductCreateDto dto = DtoFactory.MakeProductCreateDto();

            // Act
            Product entity = dto.ToEntity();

            // Assert
            entity
                .Should()
                .BeEquivalentTo(dto);
        }

        [Fact]
        public void ToEntity_NullCreateDtoToEntity_ThrowArgumentNullException()
        {
            // Arrange
            ProductCreateDto dto = null;

            // Act
            Product entity = new();

            // Assert
            entity
                .Invoking(_ => dto.ToEntity())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToEntity_UpdateDtoToEntity_ProductEntity()
        {
            // Arrange
            ProductUpdateDto dto = DtoFactory.MakeProductUpdateDto();

            // Act
            Product entity = dto.ToEntity();

            // Assert
            entity
                .Should()
                .BeEquivalentTo(dto);
        }

        [Fact]
        public void ToEntity_NullUpdateDtoToEntity_ThrowArgumentNullException()
        {
            // Arrange
            ProductUpdateDto dto = null;

            // Act
            Product entity = new();

            // Assert
            entity
                .Invoking(_ => dto.ToEntity())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToReadDto_EntityToReadDto_ProductReadDto()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            ProductReadDto dto = entity.ToReadDto();

            // Assert
            dto
                .Should()
                .BeEquivalentTo(entity, config =>
                    config
                    .Excluding(entity => entity.ProductVariations)
                    .Excluding(entity => entity.Category)
                    .Excluding(entity => entity.CreatedAt));
        }

        [Fact]
        public void ToReadDto_NullEntity_ThrowArgumentNullException()
        {
            // Arrange
            Product entity = null;

            // Act
            ProductReadDto dto = new();

            // Assert
            dto
                .Invoking(_ => entity.ToReadDto())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToUpdateDto_EntityToUpdateDto_ProductUpdateDto()
        {
            // Arrange
            Product entity = EntityFactory.MakeProduct();

            // Act
            ProductUpdateDto dto = entity.ToUpdateDto();

            // Assert
            dto
                .Should()
                .BeEquivalentTo(entity, config =>
                    config
                    .Excluding(entity => entity.ProductVariations)
                    .Excluding(entity => entity.Category)
                    .Excluding(entity => entity.CreatedAt));
        }

        [Fact]
        public void ToUpdateDto_NullEntity_ThrowArgumentNullException()
        {
            // Arrange
            Product entity = null;

            // Act
            ProductUpdateDto dto = new();

            // Assert
            dto
                .Invoking(_ => entity.ToUpdateDto())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}