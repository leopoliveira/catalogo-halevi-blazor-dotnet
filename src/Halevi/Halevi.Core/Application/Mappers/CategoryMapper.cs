using Halevi.Core.Application.DTOs.Category;
using Halevi.Core.Domain.Entities;

namespace Halevi.Core.Application.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToEntity(this CategoryDto dto)
        {
            return new Category()
            {
                Name = dto.Name,
                Code = dto.Code,
                Active = dto.Active
            };
        }

        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Code = category.Code,
                Name = category.Name,
                Active = category.Active
            };
        }
    }
}
