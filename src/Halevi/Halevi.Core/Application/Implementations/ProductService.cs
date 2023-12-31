﻿using FluentValidation;

using Halevi.Core.Application.DTOs.Product;
using Halevi.Core.Application.Interfaces;
using Halevi.Core.Application.Mappers;
using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Core.Domain.Validations;

namespace Halevi.Core.Application.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ProductValidations _validator;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
            _validator = new ProductValidations();
        }

        /// <summary>
        /// Get the product by the given Id.
        /// </summary>
        /// <param name="id">The product Id.</param>
        /// <returns>The product converted to Dto or null.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductReadDto> GetByAsync(Guid id)
        {
            try
            {
                Product product = await _repository.GetByAsync(id);

                if (product is null)
                {
                    return null;
                }

                return product.ToReadDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to Get Product by Id. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Get the product by the given Code.
        /// </summary>
        /// <param name="code">The product Code.</param>
        /// <returns>The product converted to Dto or null.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductReadDto> GetByAsync(int code)
        {
            try
            {
                Product product = await _repository.GetByAsync(code);

                if (product is null)
                {
                    return null;
                }

                return product.ToReadDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to Get Product by Code. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Verify if exists an product by the provided Id.
        /// </summary>
        /// <param name="id">The product Id.</param>
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
                throw new Exception("Failed on trying to Get Product by Id. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Verify if exists an product by the provided Code.
        /// </summary>
        /// <param name="code">The product Code.</param>
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
                throw new Exception("Failed on trying to Get Product by Code. Please try again later. Error: ", ex.InnerException);
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
        /// Create the product by the Dto and returns the code.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <returns>The created product code.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CreateAsync(ProductCreateDto dto)
        {
            try
            {
                if (dto.Code is null || dto.Code.Value <= 0)
                {
                    dto.Code = await _repository.NewEntityCode();
                }

                if (await _repository.GetByAsync(dto.Code.Value) is not null)
                {
                    throw new ArgumentException("This code already exist.");
                }

                Product product = dto.ToEntity();

                _validator.ValidateAndThrow(product);

                return await _repository.CreateAsync(product);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to create Product. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Update the product by the Dto.
        /// </summary>
        /// <param name="dto">The Dto.</param>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(ProductUpdateDto dto)
        {
            try
            {
                if (IdOrCodeNotValid(dto))
                {
                    throw new ArgumentException("The Id or Code is not valid.");
                }

                Product product = await _repository.GetByAsync(dto.Id) ??
                    throw new ArgumentException("Product not found.");

                if (IdOrCodeWasModified(dto, product))
                {
                    throw new InvalidOperationException("When update a entity, neither Id or Code can be modified.");
                }

                product = dto.ToEntity();

                _validator.ValidateAndThrow(product);

                await _repository.UpdateAsync(product);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to update Product. Please try again later. Error: ", ex.InnerException);
            }
        }

        /// <summary>
        /// Delete the product by the Id.
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Guid id)
        {
            Product product = await _repository.GetByAsync(id);

            await Delete(product);
        }

        /// <summary>
        /// Delete the entity by the code.
        /// </summary>
        /// <param name="code">The Code of the entity.</param>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int code)
        {
            Product product = await _repository.GetByAsync(code);

            await Delete(product);
        }

        private async Task Delete(Product product)
        {
            try
            {
                if (product is null)
                {
                    throw new ArgumentException("The Product was not found.");
                }

                _validator.ValidateAndThrow(product);

                await _repository.DeleteAsync(product);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Validation Errors: ", ex.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed on trying to delete Product. Please try again later. Error: ", ex.InnerException);
            }
        }

        private static bool IdOrCodeNotValid(ProductUpdateDto dto)
        {
            return dto.Id == Guid.Empty ||
                   dto.Code is null ||
                   dto.Code <= 0;
        }

        private static bool IdOrCodeWasModified(ProductUpdateDto dto, Product product)
        {
            return dto.Code != product.Code ||
                   dto.Id != product.Id;
        }
    }
}
