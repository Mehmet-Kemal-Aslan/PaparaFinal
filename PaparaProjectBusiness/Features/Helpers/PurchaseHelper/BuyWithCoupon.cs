using AutoMapper;
using Azure.Core;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class BuyWithCoupon
    {
        private readonly IUnitOfWork unitOfWork;

        public BuyWithCoupon(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<decimal> CheckCoupon(string couponCode, decimal basketPrice)
        {
            if (string.IsNullOrEmpty(couponCode))
                return basketPrice;

            Coupon? coupon = await unitOfWork.CouponReadRepository.FirstOrDefault(c => c.Code == couponCode && DateTime.Now > c.ExpireDate);

            if (coupon is null )
                return basketPrice;

            decimal balance = basketPrice - coupon.Price;

            if (balance < 0)
                return 0;

            return balance;
        }
    }
}
