using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetAllWallets
{
    public class GetAllWalletsQueryHandler : IRequestHandler<GetAllWalletsQueryRequest, GetAllWalletsQueryResponse<List<WalletResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllWalletsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetAllWalletsQueryResponse<List<WalletResponse>>> Handle(GetAllWalletsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Wallet> walletList = await unitOfWork.WalletReadRepository.GetAll();
            var mappedList = mapper.Map<List<WalletResponse>>(walletList);
            return new GetAllWalletsQueryResponse<List<WalletResponse>>(mappedList);
        }
    }
}
