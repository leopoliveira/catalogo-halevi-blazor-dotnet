using FluentValidation;

using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Validations.Base;

namespace Halevi.Core.Domain.Validations
{
    public class CategoryValidations : BaseValidation<Category>
    {
        public CategoryValidations()
        {
            RuleFor(category => category.Name)
                .NotEmpty()
                .WithMessage("Category {PropertyName} should not be null or empty.");

            RuleFor(category => category.Name)
                .MaximumLength(MAX_SHORT_STRING_LENGTH)
                .WithMessage("Category {PropertyName} has to have a maximum of {MaxLength} characters.");
        }
    }
}
