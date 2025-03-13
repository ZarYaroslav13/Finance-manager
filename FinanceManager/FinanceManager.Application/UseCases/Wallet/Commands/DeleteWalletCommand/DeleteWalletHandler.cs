using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallet.Commands.DeleteWalletCommand;

public class DeleteWalletHandler : BaseHandler, IRequestHandler<DeleteWalletCommand, BaseResponse<bool>>
{
    private readonly IWalletService _service;

    public DeleteWalletHandler(IWalletService service, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<BaseResponse<bool>> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        if (request.UsertRole != AdminService.AdminRole && !await _service.IsAccountOwnerWalletAsync(request.UsertId, request.WalletId))
        {
            _logger.LogWarning($"Unauthorized access attempt to delete wallet Id: {request.WalletId} by user Id: {request.UsertId} and role: {request.UsertRole}");
            throw new UnauthorizedAccessException($"Access to this wallet is denied");
        }

        var response = new BaseResponse<bool>();

        try
        {
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
