using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Domain.Entities;

namespace Halevi.Core.Application.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToEntity(this CategoryCreateDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto), "Dto can't be null.");
            }

            return new Category()
            {
                Name = dto.Name,
                Code = dto.Code.Value,
                Active = dto.Active
            };
        }

        public static Category ToEntity(this CategoryUpdateDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto), "Dto can't be null.");
            }

            return new Category()
            {
                Name = dto.Name,
                Id = dto.Id,
                Code = dto.Code.Value,
                Active = dto.Active
            };
        }

        public static CategoryReadDto ToReadDto(this Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category), "Category can't be null.");
            }

            return new CategoryReadDto()
            {
                Id = category.Id,
                Code = category.Code,
                Name = category.Name,
                Active = category.Active
            };
        }

        public static CategoryUpdateDto ToUpdateDto(this Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category), "Category can't be null.");
            }

            return new CategoryUpdateDto()
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Active = category.Active
            };
        }
    }
}
