using FluentValidation;

using Halevi.Core.Domain.Entities.Base;

namespace Halevi.Core.Domain.Validations.Base
{
    public class BaseValidation<TEntity> : AbstractValidator<TEntity>
        where TEntity : BaseEntitiy
    {
        public BaseValidation()
        {
            RuleFor(entity => entity.CreatedAt)
                .NotEmpty()
                .WithMessage("Entity creation date should not be null.");

            RuleFor(entity => entity.Code)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Entity {PropertyName} shold not be null and greater than zero.");
        }
    }
}
