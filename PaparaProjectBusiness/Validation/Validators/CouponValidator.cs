using FluentValidation;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Validation.Validators
{
    public class CouponValidator : AbstractValidator<CouponRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CouponValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Price).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(c => c.Code).NotEmpty().MaximumLength(10).MustAsync(BeUniqueCode);
            RuleFor(c => c.ExpireDate).NotEmpty().GreaterThan(DateTime.Now);
        }
        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
        {
            var existingCoupon = await _unitOfWork.CouponReadRepository.FirstOrDefault(c => c.Code == code);
            return existingCoupon == null;
        }
    }
}
