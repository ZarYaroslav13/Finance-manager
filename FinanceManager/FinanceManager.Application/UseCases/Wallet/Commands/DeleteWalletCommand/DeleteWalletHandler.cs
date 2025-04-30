using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallet.Commands.DeleteWalletCommand;

public class DeleteWalletHandler : BaseRequestHandler, IRequestHandler<DeleteWalletCommand, BaseResponse<bool>>
{
    private readonly IWalletService _service;

    public DeleteWalletHandler(IWalletService service, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<BaseResponse<bool>> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            if (request.UserRole != PolicyManager.AdminRole && !await _service.IsAccountOwnerWalletAsync(request.UserId, request.WalletId))
            {
                _logger.LogWarning($"Unauthorized access attempt to delete wallet Id: {request.WalletId} by user Id: {request.UserId} and role: {request.UserRole}");
                throw new UnauthorizedAccessException($"Access to this wallet is denied");
            }

            await _service.DeleteWalletByIdAsync(request.WalletId);

            response.Data = true;

            response.MakeAsSuccess($"Deleted Wallet witn id  {request.WalletId} successfully");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
