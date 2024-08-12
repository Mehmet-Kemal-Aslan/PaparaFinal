using FluentValidation;
using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class PurchaseValidator : AbstractValidator<PurchaseRequest>
    {
        public PurchaseValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.BasketId).NotEmpty();
            RuleFor(x => x.CardName).NotEmpty();
            RuleFor(x => x.CardNumber).NotEmpty().Length(16);
            RuleFor(x => x.CardExpireDate).NotEmpty();
            RuleFor(x => x.CVV).NotEmpty();
            RuleFor(x => x.CouponCode).MaximumLength(10);
        }
    }
}
