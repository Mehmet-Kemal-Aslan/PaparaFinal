using AutoMapper;
using MediatR;
using PaparaFinalData.Entity;
using PaparaProjectBase.APIResponse;
using PaparaProjectBusiness.Features.Commands.Wallets.CreateWallet;
using PaparaProjectBusiness.Validation.Validators;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Requests;
using PaparaProjectSchema.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBusiness.Features.Commands.Wallets.UpdateWallet
{
    public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommandRequest, ApiResponse<WalletResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateWalletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<WalletResponse>> Handle(UpdateWalletCommandRequest request, CancellationToken cancellationToken)
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
            mapped.Id = request.walletId;
            unitOfWork.WalletWriteRepository.Update(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<WalletResponse>(mapped);
            return new ApiResponse<WalletResponse>(response);
        }
    }
}
