using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;

namespace PaparaProjectBusiness.Features.Commands.Wallets.CreateWallet
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommandRequest, ApiResponse<WalletResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateWalletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<WalletResponse>> Handle(CreateWalletCommandRequest request, CancellationToken cancellationToken)
        {
            WalletValidator walletValidator = new WalletValidator();
            var validationResult = await walletValidator.ValidateAsync(request.walletRequest);
            ApiResponse<WalletResponse> validationResponse = new ApiResponse<WalletResponse>(null);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                validationResponse.Message = errors;
                validationResponse.IsSuccess = false;
                validationResponse.Health = true;
                return validationResponse;
            }

            var mapped = mapper.Map<WalletRequest, Wallet>(request.walletRequest);
            await unitOfWork.WalletWriteRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<WalletResponse>(mapped);
            return new ApiResponse<WalletResponse>(response);
        }
    }
}
