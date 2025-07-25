using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Domain.UseCases.FinanceOperations.Commands.DeleteFinanceOperationCommand;
using FinanceManager.Domain.UseCases.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfTypeQuery;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletInPeriodQuery;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetOperationQuery;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.IsCallerOperationOwnerQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.DeleteFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetAllFinanceOperationTypesQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetAllUserFinanceOperationTypesQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetFinanceOperationTypeQuery;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.IsCallerTypeOwnerQuery;
using FinanceManager.Domain.UseCases.Wallets.Queries.IsCallerWalletOwnerQuery;
using FinanceManager.Domain.Wrapper;
using MediatR;

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
        var command = _mapper.Map<UpdateFinanceOperationTypeCommand>(request);

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

    public async Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(GetAllOperationsOfWalletRequest request)
    {
        var command = _mapper.Map<GetAllOperationsOfWalletQuery>(request);

        var isCallerOwner = await IsCallerWallerOwnerAsync(request.WalletId);

        if (!isCallerOwner.Succeeded)
            return Result<List<FinanceOperationDTO>>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<List<FinanceOperationDTO>>>(result);
    }

    public async Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfTypeAsync(GetAllOperationsOfTypeRequest request)
    {
        var command = _mapper.Map<GetAllOperationsOfTypeQuery>(request);

        var isCallerOwner = await IsCallerTypeOwnerAsync(request.TypeId);

        if (!isCallerOwner.Succeeded)
            return Result<List<FinanceOperationDTO>>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<List<FinanceOperationDTO>>>(result);
    }

    public async Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(GetAllOperationsOfWalletInPeriodRequest request)
    {
        var command = _mapper.Map<GetAllOperationsOfWalletInPeriodQuery>(request);

        var isCallerOwner = await IsCallerWallerOwnerAsync(request.WalletId);

        if (!isCallerOwner.Succeeded)
            return Result<List<FinanceOperationDTO>>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<List<FinanceOperationDTO>>>(result);
    }

    public async Task<Result<FinanceOperationDTO>> GetFinanceOperation(Guid id)
    {
        var command = new GetOperationQuery() { Id = id };

        var isCallerOwner = await IsCallerWallerOwnerAsync(id);

        if (!isCallerOwner.Succeeded)
            return Result<FinanceOperationDTO>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<FinanceOperationDTO>>(result);
    }

    public async Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync(AddFinanceOperationRequest request)
    {
        var command = _mapper.Map<AddFinanceOperationTypeCommand>(request);

        var isCallerOwner = await IsCallerTypeOwnerAsync(request.TypeId);

        if (!isCallerOwner.Succeeded)
            return Result<FinanceOperationDTO>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<FinanceOperationDTO>>(result);
    }

    public async Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync(UpdateFinanceOperationRequest request)
    {
        var command = _mapper.Map<UpdateFinanceOperationCommand>(request);

        var isCallerOwner = await IsCallerOperationOwnerAsync(request.TypeId);

        if (!isCallerOwner.Succeeded)
            return Result<FinanceOperationDTO>.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result<FinanceOperationDTO>>(result);
    }

    public async Task<IResult> DeleteFinanceOperationAsync(Guid id)
    {

        var command = new DeleteFinanceOperationCommand() { Id = id };

        var isCallerOwner = await IsCallerOperationOwnerAsync(id);

        if (!isCallerOwner.Succeeded)
            return Result.Fail(isCallerOwner.Messages);

        command.IsCallerOwner = isCallerOwner.Data;

        var result = await _mediator.Send(command);

        return _mapper.Map<Result>(result);
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

    private async Task<IResult<bool>> IsCallerOperationOwnerAsync(Guid typeId)
    {
        var isCallerOwner = await _mediator.Send(new IsCallerOperationOwnerQuery() { Id = typeId });

        return isCallerOwner;
    }
}
