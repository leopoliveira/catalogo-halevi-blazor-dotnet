using FluentValidation;

using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Application.Interfaces;
using Halevi.Core.Application.Mappers;
using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Core.Domain.Validations;

namespace Halevi.Core.Application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly CategoryValidations _validator;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
            _validator = new CategoryValidations();
        }

        /// <summary>
        /// get the entity by the given Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<CategoryDto> GetByAsync(Guid id)
        {
            try
            {
                Category category = await _repository.GetByAsync(id);

                return category.ToDto();
            }
            catch(Exception ex)
            {
                throw new Exception("Failed on trying to get Category by Id. Please try again later. Error: ", ex.InnerException);
            }
        }
        /// <summary>
        /// get the entity by the given Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<CategoryDto> GetByAsync(int code)
        {
            try
            {
                Category category = await _repository.GetByAsync(code);

                return category.ToDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to get Category by Code. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Verify if exists an entity by the provided Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>True if exists; otherwise, false.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ExistsAsync(Guid id)
        {
            try
            {
                return await _repository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to get Category by Id. Please try again later. Error: ", ex.InnerException);
            }
        }
        /// <summary>
        /// Verify if exists an entity by the provided Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>True if exists; otherwise, false.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ExistsAsync(int code)
        {
            try
            {
                return await _repository.ExistsAsync(code);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to get Category by Code. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Count the number of the records.
        /// </summary>
        /// <returns>The number of the records.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CountAsync()
        {
            try
            {
                return await _repository.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to count records. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Create the entity by the Dto and returns the code.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <returns>The created entity code.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CreateAsync(CategoryDto dto)
        {
            try
            {
                Category entity = dto.ToEntity();

                _validator.ValidateAndThrow(entity);

                return await _repository.CreateAsync(entity);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to create Category. Please try again later. Error: ", ex.InnerException);
            }
        }
        /// <summary>
        /// Update the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(CategoryDto dto)
        {
            try
            {
                Category entity = dto.ToEntity();

                _validator.ValidateAndThrow(entity);

                await _repository.UpdateAsync(entity);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to update Category. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Delete the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(CategoryDto dto)
        {
            try
            {
                Category entity = dto.ToEntity();

                _validator.ValidateAndThrow(entity);

                await _repository.DeleteAsync(entity);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to delete Category. Please try again later. Error: ", ex.InnerException);
            }
        }
    }
}
