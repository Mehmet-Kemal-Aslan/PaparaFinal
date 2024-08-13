using FluentValidation;
using PaparaProjectSchema.Requests;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class UsersValidator : AbstractValidator<UserRequest>
    {
        public UsersValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(u => u.Surname).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(u => u.UserName).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Address).NotEmpty();
        }
    }
}
