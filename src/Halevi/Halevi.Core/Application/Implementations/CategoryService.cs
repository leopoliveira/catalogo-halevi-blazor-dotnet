using FluentValidation;

using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Application.Interfaces;
using Halevi.Core.Application.Mappers;
using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Core.Domain.Utils;
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
        /// get the category by the given Id.
        /// </summary>
        /// <param name="id">The category Id.</param>
        /// <returns>The category converted to Dto or null.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<CategoryReadDto> GetByAsync(Guid id)
        {
            try
            {
                Category category = await _repository.GetByAsync(id);

                if (category is null)
                {
                    return null;
                }

                return category.ToReadDto();
            }
            catch(Exception ex)
            {
                throw new Exception("Failed on trying to get Category by Id. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// get the category by the given Code.
        /// </summary>
        /// <param name="code">The category Code.</param>
        /// <returns>The category converted to Dto or null.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<CategoryReadDto> GetByAsync(int code)
        {
            try
            {
                Category category = await _repository.GetByAsync(code);

                if (category is null)
                {
                    return null;
                }

                return category.ToReadDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to get Category by Code. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>The list of entities converted to Dto or null.</returns>
        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Category> listOfCategories = await _repository.GetAllAsync();

                if (listOfCategories is null || !listOfCategories.Any())
                {
                    return null;
                }

                return listOfCategories.Select(x => x.ToReadDto());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to get all categories. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Verify if exists an category by the provided Id.
        /// </summary>
        /// <param name="id">The category Id.</param>
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
        /// Verify if exists an category by the provided Code.
        /// </summary>
        /// <param name="code">The category Code.</param>
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
        /// Create the category by the Dto and returns the code.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <returns>The created category code.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CreateAsync(CategoryCreateDto dto)
        {
            try
            {
                if (dto.Code is null || dto.Code.Value <= 0)
                {
                    dto.Code = await _repository.NewEntityCode();
                }

                Category category = dto.ToEntity();

                _validator.ValidateAndThrow(category);

                return await _repository.CreateAsync(category);
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
        /// Update the category by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(CategoryUpdateDto dto)
        {
            try
            {
                Category category = dto.ToEntity();

                _validator.ValidateAndThrow(category);

                await _repository.UpdateAsync(category);
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
        /// Delete the category by the Id.
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                Category category = await _repository.GetByAsync(id);

                if (category is null)
                {
                    throw new ArgumentException("The Category was not found.");
                }

                _validator.ValidateAndThrow(category);

                await _repository.DeleteAsync(category);
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
