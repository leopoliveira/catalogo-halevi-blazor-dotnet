using Halevi.API.Controllers.v1.Base;
using Halevi.Core.Application.DTOs.Product;
using Halevi.Core.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Halevi.API.Controllers.v1
{
    /// <summary>
    /// Product Controller Implementation.
    /// </summary>
    public class ProductController : BaseController
    {
        private readonly IProductService _service;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="service">IProductService</param>
        public ProductController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>The Product or NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductReadDto>> GetById(string id)
        {
            if (Guid.TryParse(id, out Guid categoryId))
            {
                return BadRequest("The id is in an invalid format.");
            }

            var product = await _service.GetByAsync(categoryId);

            return product is null ?
                   NotFound() :
                   Ok(product);
        }

        /// <summary>
        /// Get Product by Code.
        /// </summary>
        /// <param name="code">Product Code.</param>
        /// <returns>The Product or NotFound.</returns>
        [HttpGet("{code:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductReadDto>> GetByCode(int code)
        {
            if (code <= 0)
            {
                return BadRequest("The code is in invalid. It should be greater than zero.");
            }

            var product = await _service.GetByAsync(code);

            return product is null ?
                   NotFound() :
                   Ok(product);
        }

        /// <summary>
        /// Create a Product.
        /// </summary>
        /// <param name="product">The product data.</param>
        /// <returns>The code of created Product if creation was successeful or BadRequest.</returns>
        /// <remarks>
        ///     Code is optional.
        ///     If code was not passed or is less than or equal to zero, a code will be added by the application.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(ProductCreateDto product)
        {
            int resultCode = await _service.CreateAsync(product);

            return CreatedAtAction(nameof(GetByCode), new { code = resultCode }, product);
        }

        /// <summary>
        /// Update the given Product.
        /// </summary>
        /// <param name="product">The product.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(ProductUpdateDto product)
        {
            await _service.UpdateAsync(product);

            return Ok(Url.Action(nameof(GetById), new { id = product.Id }));
        }

        /// <summary>
        /// Deletes the product by id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        [HttpDelete("DeleteById/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(string id)
        {
            if (Guid.TryParse(id, out Guid categoryId))
            {
                return BadRequest("The id is in an invalid format.");
            }

            await _service.DeleteAsync(categoryId);

            return NoContent();
        }

        /// <summary>
        /// Deletes the product by code.
        /// </summary>
        /// <param name="code">Product Code.</param>
        [HttpDelete("{code}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int code)
        {
            if (code <= 0)
            {
                return BadRequest("The code is in an invalid format.");
            }

            await _service.DeleteAsync(code);

            return NoContent();
        }
    }
}
