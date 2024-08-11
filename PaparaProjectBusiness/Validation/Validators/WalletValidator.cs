using FluentValidation;
using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class WalletValidator : AbstractValidator<WalletRequest>
    {
        public WalletValidator()
        {
            RuleFor(w => w.Money).GreaterThanOrEqualTo(0);
            RuleFor(w => w.UserId).NotEmpty();
        }
    }
}
