using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallets.Commands.DeleteWalletCommand;

public class DeleteWalletHandler : BaseRequestHandler, IRequestHandler<DeleteWalletCommand, IResult>
{
    private readonly IWalletService _service;

    public DeleteWalletHandler(IWalletService service,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<IResult> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {

            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _service.IsCallerWalletOwner(request.WalletId));

            await _service.DeleteWalletByIdAsync(request.WalletId);

            return Result.Success("Deleted wallet successfully!");
        });
    }
}
