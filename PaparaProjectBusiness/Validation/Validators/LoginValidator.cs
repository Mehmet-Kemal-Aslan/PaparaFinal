using FluentValidation;
using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(2);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
