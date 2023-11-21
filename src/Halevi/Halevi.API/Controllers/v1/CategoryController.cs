using Halevi.API.Controllers.v1.Base;
using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Application.Helpers;
using Halevi.Core.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Halevi.API.Controllers.v1
{
    /// <summary>
    /// Category Controller Implementation.
    /// </summary>
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _service;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="service">ICaregoryServiceInstance</param>
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all Categories.
        /// </summary>
        /// <returns>All Categories or NotFound.</returns>
        // api/v1/Category
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> Get()
        {
            var categories = await _service.GetAllAsync();

            return categories is null ?
                   NotFound() :
                   Ok(categories);
        }

        /// <summary>
        /// Get Category by Id.
        /// </summary>
        /// <param name="id">Category Id.</param>
        /// <returns>The Category or NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryReadDto>> GetById(string id)
        {
            if (Guid.TryParse(id, out Guid categoryId))
            {
                return BadRequest("The id is in an invalid format.");
            }

            var category = await _service.GetByAsync(categoryId);

            return category is null ?
                   NotFound() :
                   Ok(category);
        }

        /// <summary>
        /// Get Category by Code.
        /// </summary>
        /// <param name="code">Category Code.</param>
        /// <returns>The Category or NotFound.</returns>
        [HttpGet("{code:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryReadDto>> GetByCode(int code)
        {
            if (code <= 0)
            {
                return BadRequest("The code is in invalid. It should be greater than zero.");
            }

            var category = await _service.GetByAsync(code);

            return category is null ?
                   NotFound() :
                   Ok(category);
        }

        /// <summary>
        /// Create a Category.
        /// </summary>
        /// <param name="category">The category data.</param>
        /// <returns>The code of created Category if creation was successeful or BadRequest.</returns>
        /// <remarks>
        ///     Code is optional.
        ///     If code was not passed or is less than or equal to zero, a code will be added by the application.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(CategoryCreateDto category)
        {
            int resultCode = await _service.CreateAsync(category);

            return CreatedAtAction(nameof(GetByCode), new { code = resultCode }, category);
        }
    }
}
