using FluentValidation;
using PaparaProjectSchema.Requests;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Url).NotEmpty();
        }
    }
}
