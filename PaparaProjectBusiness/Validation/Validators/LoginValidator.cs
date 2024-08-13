using FluentValidation;
using PaparaProjectSchema.Requests;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
