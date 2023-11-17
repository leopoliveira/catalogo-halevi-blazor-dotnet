using FluentValidation;

using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Validations.Base;

namespace Halevi.Core.Domain.Validations
{
    public class ProductValidations : BaseValidation<Product>
    {
        public ProductValidations()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Product {PropertyName} should not be null or empty.");

            RuleFor(product => product.Name)
                .MaximumLength(MAX_SHORT_STRING_LENGTH)
                .WithMessage("Product {PropertyName} has to have a maximum of {MaxLength} characters.");

            RuleFor(product => product.Description)
                .MaximumLength(MAX_LONG_TEXT_LENGTH)
                .WithMessage("Product {PropertyName} has to have a maximum of {MaxLength} characters.");

            RuleFor(product => product.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Product {PropertyName} should be greater than zero.");

            RuleFor(product => product.CategoryId)
                .NotEmpty()
                .WithMessage("A Category must be especified.");
        }
    }
}
