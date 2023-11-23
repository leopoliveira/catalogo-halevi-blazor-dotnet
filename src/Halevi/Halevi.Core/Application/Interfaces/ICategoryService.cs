using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Application.Mappers;
using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Core.Domain.Utils;

namespace Halevi.Core.Application.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get the entity by the given Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public Task<CategoryReadDto> GetByAsync(Guid id);

        /// <summary>
        /// Get the entity by the given Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public Task<CategoryReadDto> GetByAsync(int code);

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>The list of entities converted to Dto.</returns>
        public Task<IEnumerable<CategoryReadDto>> GetAllAsync();

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
        public Task<int> CreateAsync(CategoryCreateDto dto);

        /// <summary>
        /// Update the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public Task UpdateAsync(CategoryUpdateDto dto);

        /// <summary>
        /// Delete the entity by the id.
        /// </summary>
        /// <param name="id">The Id of the entity.</param>
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
