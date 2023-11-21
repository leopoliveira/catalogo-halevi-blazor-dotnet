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
        /// Get the variation by the given Id.
        /// </summary>
        /// <param name="id">The variation Id.</param>
        /// <returns>The variation converted to Dto or null.</returns>
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
        /// Get the variation by the given Code.
        /// </summary>
        /// <param name="code">The variation Code.</param>
        /// <returns>The variation converted to Dto or null.</returns>
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
        /// Verify if exists an variation by the provided Id.
        /// </summary>
        /// <param name="id">The variation Id.</param>
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
        /// Verify if exists an variation by the provided Code.
        /// </summary>
        /// <param name="code">The variation Code.</param>
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
        /// Create the variation by the Dto and returns the code.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <returns>The created variation code.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CreateAsync(ProductVariationCreateDto dto)
        {
            try
            {
                if (dto.Code is null || dto.Code.Value <= 0)
                {
                    dto.Code = _repository.GetLastCode() + 1;
                }

                ProductVariation variation = dto.ToEntity();

                _validator.ValidateAndThrow(variation);

                return await _repository.CreateAsync(variation);
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
        /// Update the variation by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(ProductVariationUpdateDto dto)
        {
            try
            {
                ProductVariation variation = dto.ToEntity();

                _validator.ValidateAndThrow(variation);

                await _repository.UpdateAsync(variation);
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
        /// Delete the variation by the Id.
        /// </summary>
        /// <param name="id">The variation id.</param>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                ProductVariation variation = await _repository.GetByAsync(id);

                if (variation is null)
                {
                    throw new ArgumentException("The Product Variation was not found.");
                }

                _validator.ValidateAndThrow(variation);

                await _repository.DeleteAsync(variation);
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
