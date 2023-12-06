using Halevi.API.Controllers.v1;
using Halevi.Core.Application.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Halevi.Tests.Unit.APIControllers.v1
{
    public class CategoryControllerTest
    {
        private readonly ICategoryService _service;
        private readonly CategoryController _controller;

        public CategoryControllerTest()
        {
            _service = Substitute.For<ICategoryService>();
            _controller = new CategoryController(_service);
        }

        [Fact]
        //Method_Scenario_Result
        public async Task GetAll_CategoriesExist_ReturnOkWithCategories()
        {
            // Arrange
            var dtos = DtoFactory.MakeListOfCategoryReadDto();

            _service
                .GetAllAsync()
                .Returns(dtos);

            // Act
            var result = await _controller.Get();

            // Assert
            result.Result
                .Should()
                .BeOfType<OkObjectResult>();

            result.Result
                .As<OkObjectResult>()
                .Value
                .Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(dtos);
        }

        [Fact]
        public async Task GetAll_CategoriesNotExist_ReturnNotFound()
        {
            // Arrange
            List<CategoryReadDto> dtos = null;

            _service
                .GetAllAsync()
                .Returns(dtos);

            // Act
            var result = await _controller.Get();

            // Assert
            result
                .Result
                .Should()
                .BeOfType<NotFoundResult>();
        }
    }
}
