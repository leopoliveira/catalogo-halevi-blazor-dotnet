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
        /// <returns>All Categories.</returns>
        // api/v1/Category
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
