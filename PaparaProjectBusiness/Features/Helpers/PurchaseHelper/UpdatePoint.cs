using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class UpdatePoint
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdatePoint(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async void Update(int userId, decimal pointMultiplierPercentage, decimal moneytoCalculatePoint)
        {
            User user = await unitOfWork.UserReadRepository.GetById(userId);
            decimal point = user.Point ?? 0;
            decimal newPoint = point + pointMultiplierPercentage * moneytoCalculatePoint;
            unitOfWork.UserWriteRepository.Update(user);
            unitOfWork.Complete();
        }
    }
}
