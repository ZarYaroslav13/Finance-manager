using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;

public class CreateWalletHandler : BaseRequestHandler, IRequestHandler<CreateWalletCommand, Result<WalletDTO>>
{
    private readonly IWalletService _service;

    public CreateWalletHandler(IWalletService service,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Result<WalletDTO>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(_currentUserService.UserId == request.AccountId.ToString()));

            var data = _mapper.Map<WalletDTO>(
                await _service.AddWalletAsync(
                    _mapper.Map<WalletModel>(request)));

            return Result<WalletDTO>.Success(data, "Wallet created successfully");
        });
    }
}
