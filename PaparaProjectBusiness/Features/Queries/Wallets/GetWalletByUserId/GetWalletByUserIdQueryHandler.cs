using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.Models.Messages;
using PaparaProjectBusiness.Features.Queries.Categories.GetCategoryById;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Queries.Wallets.GetWalletById
{
    public class GetWalletByUserIdQueryHandler : IRequestHandler<GetWalletByUserIdQueryRequest, GetWalletByUserIdQueryResponse<WalletResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetWalletByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetWalletByUserIdQueryResponse<WalletResponse>> Handle(GetWalletByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Wallet> walletList = await unitOfWork.WalletReadRepository.Where(w => w.UserId == request.UserId);
            if (walletList == null || !walletList.Any())
            {
                GetWalletByUserIdQueryResponse<WalletResponse> nullResponse = new GetWalletByUserIdQueryResponse<WalletResponse>(null);
                nullResponse.Message = ResponseMessages.NotFound;
                return nullResponse;
            }
            List<WalletResponse> mappedWallets = mapper.Map<List<WalletResponse>>(walletList);
            return new GetWalletByUserIdQueryResponse<WalletResponse>(mappedWallets);
        }
    }
}
