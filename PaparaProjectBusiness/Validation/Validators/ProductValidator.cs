using FluentValidation;
using PaparaProjectSchema.Requests;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class ProductValidator : AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(p => p.Stock).NotEmpty();
            RuleFor(p => p.Price).NotEmpty().GreaterThan(0);
            RuleFor(p => p.PointMultiplierPercentage).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(p => p.Features).MaximumLength(1000);
            RuleFor(p => p.Description).MaximumLength(2000);
        }
    }
}
