using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Domain.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.UseCases.Wallets.Commands.DeleteWalletCommand;
using FinanceManager.Domain.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.UseCases.Wallets.Queries.GetByIdWalletQuery;
using FinanceManager.Domain.UseCases.Wallets.Queries.GetWalletsQuery;
using FinanceManager.Domain.UseCases.Wallets.Queries.IsCallerWalletOwnerQuery;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.Services.Wallets;

public class WalletService : BaseService, IWalletService
{
    public WalletService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<Result<List<WalletDTO>>> GetAllWalletsOfAccountAsync(Guid accountId)
    {
        var result = await _mediator.Send(new GetWalletsQuery() { AccountId = accountId });

        return _mapper.Map<Result<List<WalletDTO>>>(result);
    }

    public async Task<Result<WalletDTO>> FindWalletAsync(Guid id)
    {
        var result = await _mediator.Send(new GetByIdWalletQuery() { WalletId = id });

        return _mapper.Map<Result<WalletDTO>>(result);
    }

    public async Task<Result<WalletDTO>> AddWalletAsync(CreateWalletRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<CreateWalletCommand>(request));

        return _mapper.Map<Result<WalletDTO>>(result);
    }

    public async Task<Result<WalletDTO>> UpdateWalletAsync(UpdateWalletRequest request)
    {
        var isUserOwnerReport = await _mediator.Send(new IsCallerWalletOwnerQuery() { WalletId = request.Id });

        if (!isUserOwnerReport.Succeeded)
            return Result<WalletDTO>.Fail(isUserOwnerReport.Messages);

        var updateCommand = _mapper.Map<UpdateWalletCommand>(request);

        updateCommand.IsUserOwner = isUserOwnerReport.Data;

        var result = await _mediator.Send(updateCommand);

        return _mapper.Map<Result<WalletDTO>>(result);
    }

    public async Task<IResult> DeleteWalletByIdAsync(Guid id)
    {
        var isUserOwnerReport = await _mediator.Send(new IsCallerWalletOwnerQuery() { WalletId = id });

        if (!isUserOwnerReport.Succeeded)
            return isUserOwnerReport;

        var result = await _mediator.Send(new DeleteWalletCommand() { WalletId = id, IsUserOwner = isUserOwnerReport.Data });

        return _mapper.Map<Result>(result);
    }

    public async Task<IResult<bool>> IsCallerWalletOwnerAsync(Guid walletId)
    {
        var isCallerOwner = await _mediator.Send(new IsCallerWalletOwnerQuery() { WalletId = walletId });

        return isCallerOwner;
    }
}
