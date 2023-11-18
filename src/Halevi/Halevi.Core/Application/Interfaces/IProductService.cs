using Halevi.Core.Application.DTOs.Product;

namespace Halevi.Core.Application.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Get the entity by the given Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public Task<ProductReadDto> GetByAsync(Guid id);
        /// <summary>
        /// Get the entity by the given Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<ProductReadDto> GetByAsync(int code);

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
        public Task<int> CreateAsync(ProductCreateDto dto);
        /// <summary>
        /// Update the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public Task UpdateAsync(ProductCreateDto dto);

        /// <summary>
        /// Delete the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public Task DeleteAsync(ProductCreateDto dto);
    }
}
