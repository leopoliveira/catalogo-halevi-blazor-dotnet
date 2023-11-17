using FluentValidation;

using Halevi.Core.Domain.Entities;
using Halevi.Core.Domain.Validations.Base;

namespace Halevi.Core.Domain.Validations
{
    public class ProductVariationValidations : BaseValidation<ProductVariation>
    {
        public ProductVariationValidations()
        {
            RuleFor(variation => variation.Name)
                .NotEmpty()
                .WithMessage("Product Variation {PropertyName} should not be null or empty.");

            RuleFor(variation => variation.ProductId)
                .NotEmpty()
                .WithMessage("A Product must be especified.");
        }
    }
}
