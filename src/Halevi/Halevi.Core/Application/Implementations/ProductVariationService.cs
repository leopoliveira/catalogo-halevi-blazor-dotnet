using FluentValidation;

using Halevi.Core.Application.DTOs.ProductVariation;
using Halevi.Core.Application.Interfaces;
using Halevi.Core.Application.Mappers;
using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Core.Domain.Validations;

namespace Halevi.Core.Application.Implementations
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationRepository _repository;
        private readonly ProductVariationValidations _validator;

        public ProductVariationService(IProductVariationRepository repository)
        {
            _repository = repository;
            _validator = new ProductVariationValidations();
        }

        /// <summary>
        /// Get the entity by the given Id.
        /// </summary>
        /// <param name="id">The entity Id.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductVariationReadDto> GetByAsync(Guid id)
        {
            try
            {
                ProductVariation variation = await _repository.GetByAsync(id);

                if (variation is null)
                {
                    return null;
                }

                return variation.ToReadDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to Get Product Variation by Id. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Get the entity by the given Code.
        /// </summary>
        /// <param name="code">The entity Code.</param>
        /// <returns>The entity converted to Dto.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductVariationReadDto> GetByAsync(int code)
        {
            try
            {
                ProductVariation variation = await _repository.GetByAsync(code);

                if (variation is null)
                {
                    return null;
                }

                return variation.ToReadDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to Get Product Variation by Code. Please try again later. Error: ", ex.InnerException);
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
                throw new Exception("Failed on trying to Get Product Variation by Id. Please try again later. Error: ", ex.InnerException);
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
                throw new Exception("Failed on trying to Get Product Variation by Code. Please try again later. Error: ", ex.InnerException);
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
        public async Task<int> CreateAsync(ProductVariationCreateDto dto)
        {
            try
            {
                ProductVariation entity = dto.ToEntity();

                _validator.ValidateAndThrow(entity);

                return await _repository.CreateAsync(entity);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to create Product Variation. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Update the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(ProductVariationCreateDto dto)
        {
            try
            {
                ProductVariation entity = dto.ToEntity();

                _validator.ValidateAndThrow(entity);

                await _repository.UpdateAsync(entity);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to update Product Variation. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Delete the entity by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(ProductVariationCreateDto dto)
        {
            try
            {
                ProductVariation entity = dto.ToEntity();

                _validator.ValidateAndThrow(entity);

                await _repository.DeleteAsync(entity);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to delete Product Variation. Please try again later. Error: ", ex.InnerException);
            }
        }
    }
}
