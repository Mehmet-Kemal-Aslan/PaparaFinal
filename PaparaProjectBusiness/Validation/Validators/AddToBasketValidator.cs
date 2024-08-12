using FluentValidation;
using PaparaProjectBusiness.Features.Commands.AddToBasket.AddToBasket;
using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class AddToBasketValidator : AbstractValidator<AddToBasketRequest>
    {
        public AddToBasketValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}
