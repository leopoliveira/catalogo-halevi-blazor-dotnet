using Halevi.API.Controllers.v1.Base;
using Halevi.Core.Application.DTOs.ProductVariation;
using Halevi.Core.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Halevi.API.Controllers.v1
{
    /// <summary>
    /// ProductVariation Vartation Controller Implementation.
    /// </summary>
    public class ProductVariationController : BaseController
    {
        private readonly IProductVariationService _service;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="service">IProductVariationService</param>
        public ProductVariationController(IProductVariationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get ProductVariation by Id.
        /// </summary>
        /// <param name="id">ProductVariation Id.</param>
        /// <returns>The ProductVariation or NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductVariationReadDto>> GetById(string id)
        {
            if (Guid.TryParse(id, out Guid variationId))
            {
                return BadRequest("The id is in an invalid format.");
            }

            var variation = await _service.GetByAsync(variationId);

            return variation is null ?
                   NotFound() :
                   Ok(variation);
        }

        /// <summary>
        /// Get ProductVariation by Code.
        /// </summary>
        /// <param name="code">ProductVariation Code.</param>
        /// <returns>The ProductVariation or NotFound.</returns>
        [HttpGet("{code:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductVariationReadDto>> GetByCode(int code)
        {
            if (code <= 0)
            {
                return BadRequest("The code is in invalid. It should be greater than zero.");
            }

            var variation = await _service.GetByAsync(code);

            return variation is null ?
                   NotFound() :
                   Ok(variation);
        }

        /// <summary>
        /// Get ProductVariation by ProductId.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>The list of ProductVariations or NotFound.</returns>
        [HttpGet("productId/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductVariationReadDto>> GetByProductId(string productId)
        {
            if (Guid.TryParse(productId, out Guid productGuid))
            {
                return BadRequest("The id is in an invalid format.");
            }

            var variations = await _service.GetByProduct(productGuid);

            return variations is null ?
                   NotFound() :
                   Ok(variations);
        }

        /// <summary>
        /// Get ProductVariation by Product Code.
        /// </summary>
        /// <param name="productCode">Product Code.</param>
        /// <returns>The list of ProductVariations or NotFound.</returns>
        [HttpGet("productCode/{code:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductVariationReadDto>> GetByProductCode(int productCode)
        {
            if (productCode <= 0)
            {
                return BadRequest("The code is in an invalid format.");
            }

            var variations = await _service.GetByProduct(productCode);

            return variations is null ?
                   NotFound() :
                   Ok(variations);
        }

        /// <summary>
        /// Create a ProductVariation.
        /// </summary>
        /// <param name="variation">The variation data.</param>
        /// <returns>The code of created ProductVariation if creation was successeful or BadRequest.</returns>
        /// <remarks>
        ///     Code is optional.
        ///     If code was not passed or is less than or equal to zero, a code will be added by the application.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(ProductVariationCreateDto variation)
        {
            int resultCode = await _service.CreateAsync(variation);

            return CreatedAtAction(nameof(GetByCode), new { code = resultCode }, variation);
        }

        /// <summary>
        /// Update the given ProductVariation.
        /// </summary>
        /// <param name="variation">The variation.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(ProductVariationUpdateDto variation)
        {
            await _service.UpdateAsync(variation);

            return Ok(Url.Action(nameof(GetById), new { id = variation.Id }));
        }

        /// <summary>
        /// Deletes the variation by id.
        /// </summary>
        /// <param name="id">ProductVariation Id.</param>
        [HttpDelete("DeleteById/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(string id)
        {
            if (Guid.TryParse(id, out Guid variationId))
            {
                return BadRequest("The id is in an invalid format.");
            }

            await _service.DeleteAsync(variationId);

            return NoContent();
        }

        /// <summary>
        /// Deletes the variation by code.
        /// </summary>
        /// <param name="code">ProductVariation Code.</param>
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
