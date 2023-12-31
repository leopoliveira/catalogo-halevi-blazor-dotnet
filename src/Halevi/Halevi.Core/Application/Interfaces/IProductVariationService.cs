﻿using Halevi.Core.Application.DTOs.ProductVariation;

namespace Halevi.Core.Application.Interfaces
{
    public interface IProductVariationService
    {
        /// <summary>
        /// Get the entity by the given Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public Task<ProductVariationReadDto> GetByAsync(Guid id);

        /// <summary>
        /// Get the entity by the given Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<ProductVariationReadDto> GetByAsync(int code);

        /// <summary>
        /// Get the entities by the given Product Code.
        /// </summary>
        /// <param name="productCode">The Product code.</param>
        /// <returns>The list of entities converted to list of Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<IEnumerable<ProductVariationReadDto>> GetByProduct(int productCode);

        /// <summary>
        /// Get the entities by the given Product Id.
        /// </summary>
        /// <param name="productId">The Product id.</param>
        /// <returns>The list of entities converted to list of Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<IEnumerable<ProductVariationReadDto>> GetByProduct(Guid productId);

        /// <summary>
        /// Verify if exists an entity by the provided Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>True if exists; otherwise, false.</returns>
        /// <exception cref="Exception"></exception>
        public Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Verify if exists an entity by the provided Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>True if exists; otherwise, false.</returns>
        /// <exception cref="Exception"></exception>
        public Task<bool> ExistsAsync(int code);

        /// <summary>
        /// Count the number of the records.
        /// </summary>
        /// <returns>The number of the records.</returns>
        /// <exception cref="Exception"></exception>
        public Task<int> CountAsync();

        /// <summary>
        /// Create the entity by the Dto and returns the code.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <returns>The created entity code.</returns>
        /// <exception cref="Exception"></exception>
        public Task<int> CreateAsync(ProductVariationCreateDto dto);

        /// <summary>
        /// Update the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public Task UpdateAsync(ProductVariationUpdateDto dto);

        /// <summary>
        /// Delete the entity by the Id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <exception cref="Exception"></exception>
        public Task DeleteAsync(Guid id);

        /// <summary>
        /// Delete the entity by the code.
        /// </summary>
        /// <param name="code">The Code of the entity.</param>
        /// <exception cref="Exception"></exception>
        public Task DeleteAsync(int code);
    }
}
