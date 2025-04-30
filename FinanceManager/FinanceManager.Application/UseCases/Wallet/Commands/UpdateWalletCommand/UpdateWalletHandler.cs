using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallet.Commands.UpdateWalletCommand;

public class UpdateWalletHandler : BaseRequestHandler, IRequestHandler<UpdateWalletCommand, BaseResponse<WalletDTO>>
{
    private readonly IWalletService _service;

    public UpdateWalletHandler(IWalletService service, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<BaseResponse<WalletDTO>> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        if (request.AccountId != request.UserId && request.UserRole != PolicyManager.AdminRole)
        {
            _logger.LogWarning($"Unauthorized access attempt to update wallet with Id: {request.Id} for user Id: {request.Id} by user with id: {request.UserId}");
            throw new UnauthorizedAccessException($"Access to this wallet is denied");
        }

        var response = new BaseResponse<WalletDTO>();

        try
        {
            response.Data = _mapper.Map<WalletDTO>(
                                await _service.UpdateWalletAsync(
                                    _mapper.Map<WalletModel>(request)));

            response.MakeAsSuccess("Updated successfully");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
