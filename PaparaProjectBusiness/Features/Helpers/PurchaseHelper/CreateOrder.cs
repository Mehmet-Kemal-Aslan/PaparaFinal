using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Helpers.PurchaseHelper
{
    public class CreateOrder
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CreateOrder(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<OrderResponse>Create(int userId, int basketId)
        {
            User user = await unitOfWork.UserReadRepository.GetById(userId);
            Basket basket = await unitOfWork.BasketReadRepository.GetById(basketId);
            Order newOrder = new Order
            {
                UserId = user.Id,
                Address = user.Address,
                Price = basket.Price,
                BasketId = basketId,
                DateTime = DateTime.Now,
            };
            await unitOfWork.OrderWriteRepository.Insert(newOrder);
            await unitOfWork.Complete();

            Order resultOrder = await unitOfWork.OrderReadRepository.FirstOrDefault(o => o.BasketId == basketId);
            var result = mapper.Map<OrderResponse>(resultOrder);
            await unitOfWork.BasketWriteRepository.Delete(basketId);
            await unitOfWork.Complete();
            return result;
        }
    }
}
