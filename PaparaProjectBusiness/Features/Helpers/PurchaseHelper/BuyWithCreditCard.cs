using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class BuyWithCreditCard
    {
        public async Task<bool> CheckCreditCard(DateOnly expireDate, int CVV)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            if (currentDate >= expireDate || CVV < 100 || CVV > 999)
                return false;

            return true;
        }
    }
}
