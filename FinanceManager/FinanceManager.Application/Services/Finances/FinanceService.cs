using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.DeleteFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetAllFinanceOperationTypesQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetAllUserFinanceOperationTypesQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetFinanceOperationTypeQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.IsCallerTypeOwnerQuery;
using FinanceManager.Domain.UseCases.Wallets.Commands.DeleteWalletCommand;
using FinanceManager.Domain.UseCases.Wallets.Queries.IsCallerWalletOwnerQuery;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.Collections.Generic;

namespace FinanceManager.Application.Services.Finances;

public class FinanceService : BaseService, IFinanceService
{
    public FinanceService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<Result<List<FinanceOperationTypeDTO>>> GetAllUserFinanceOperationTypesAsync(Guid userId)
    {
        var result = await _mediator.Send(new GetAllUserFinanceOperationTypesQuery() { UserId = userId });

        return _mapper.Map<Result<List<FinanceOperationTypeDTO>>>(result);
    }

    public async Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesOfWalletAsync(Guid walletId)
    {
        var command = new GetWalletFinanceOperationTypesQuery() { WalletId = walletId };

        var isCallerOwner = await IsCallerWallerOwnerAsync(walletId);

        if (!isCallerOwner.Succeeded)
            return Result<List<FinanceOperationTypeDTO>>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<List<FinanceOperationTypeDTO>>>(result);
    }

    public async Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationType(Guid id)
    {
        var command = new GetFinanceOperationTypeQuery() { Id = id };

        var isCallerOwner = await IsCallerWallerOwnerAsync(id);

        if (!isCallerOwner.Succeeded)
            return Result<FinanceOperationTypeDTO>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<FinanceOperationTypeDTO>>(result);
    }

    public async Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync(AddFinanceOperationTypeRequest request)
    {
        var command = _mapper.Map<AddFinanceOperationTypeCommand>(request);

        var isCallerOwner = await IsCallerWallerOwnerAsync(request.WalletId);

        if (!isCallerOwner.Succeeded)
            return Result<FinanceOperationTypeDTO>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<FinanceOperationTypeDTO>>(result);
    }

    public async Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync(UpdateFinanceOperationTypeRequest request)
    {
        var command = _mapper.Map<UpdateFinanceOperationCommand>(request);

        var isCallerOwner = await IsCallerWallerOwnerAsync(request.WalletId);

        if (!isCallerOwner.Succeeded)
            return Result<FinanceOperationTypeDTO>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<FinanceOperationTypeDTO>>(result);
    }

    public async Task<IResult> DeleteFinanceOperationTypeAsync(Guid id)
    {
        var command = new DeleteFinanceOperationTypeCommand() { Id = id };

        var isCallerOwner = await IsCallerTypeOwnerAsync(id);

        if (!isCallerOwner.Succeeded)
            return Result.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result>(result);
    }

    public async Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(Guid walletId, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(Guid walletId, int index = 0, int count = 0)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfTypeAsync(Guid typeId, int index = 0, int count = 0)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<FinanceOperationDTO>> GetFinanceOperation(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync(FinanceOperationDTO financeOperation)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync(FinanceOperationDTO financeOperation)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> DeleteFinanceOperationAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    private async Task<IResult<bool>> IsCallerWallerOwnerAsync(Guid walletId)
    {
        var isCallerOwner = await _mediator.Send(new IsCallerWalletOwnerQuery() { WalletId = walletId });

        return isCallerOwner;
    }

    private async Task<IResult<bool>> IsCallerTypeOwnerAsync(Guid typeId)
    {
        var isCallerOwner = await _mediator.Send(new IsCallerTypeOwnerQuery() { Id = typeId });

        return isCallerOwner;
    }
}
