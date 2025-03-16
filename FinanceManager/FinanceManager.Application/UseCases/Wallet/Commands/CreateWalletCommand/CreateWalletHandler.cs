using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;

public class CreateWalletHandler : BaseHandler, IRequestHandler<CreateWalletCommand, BaseResponse<WalletDTO>>
{
    private readonly IWalletService _service;

    public CreateWalletHandler(IWalletService service, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<BaseResponse<WalletDTO>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<WalletDTO>();

        try
        {
            AuthorizationCheck(request, r => r.AccountId);

            response.Data = _mapper.Map<WalletDTO>(
                await _service.AddWalletAsync(
                    _mapper.Map<WalletModel>(request)));

            response.MakeAsSuccess("Wallet created successfully"); ;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
