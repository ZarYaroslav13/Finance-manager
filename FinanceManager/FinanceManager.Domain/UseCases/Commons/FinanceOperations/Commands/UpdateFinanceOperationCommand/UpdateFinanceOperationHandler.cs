using AutoMapper;
using FinanceManager.Domain.Extentions;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperations.Commands.UpdateFinanceOperationCommand;

public class UpdateFinanceOperationHandler : BaseRequestHandler, IRequestHandler<UpdateFinanceOperationCommand, Result<FinanceOperationModel>>
{
    private readonly IRepository<FinanceOperation> _repository;
    private readonly IRepository<Wallet> _walletRepository;
    public UpdateFinanceOperationHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
        _walletRepository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<Result<FinanceOperationModel>> Handle(UpdateFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            var oldOperation = _mapper.Map<FinanceOperationModel>(await _repository.GetByIdAsync(request.Id));

            var dbResult = _repository.Update(
                                _mapper.Map<FinanceOperation>(request));
            await _unitOfWork.SaveChangesAsync();

            dbResult.Type = await _unitOfWork.GetRepository<FinanceOperationType>().GetByIdAsync(dbResult.TypeId);
            var data = _mapper.Map<FinanceOperationModel>(dbResult);

            await UpdateWalletAfterUpdatingOperation(data, oldOperation.Type.EntryType, oldOperation.Amount);

            return Result<FinanceOperationModel>.Success(data, "Finance operation updated successfully!");
        });
    }

    private async Task UpdateWalletAfterUpdatingOperation(FinanceOperationModel financeOperation, EntryType oldType, int oldAmount)
    {
        var type = financeOperation.Type;

        if (oldAmount == financeOperation.Amount && oldType == type.EntryType)
            return;

        var wallet = await _walletRepository.GetByIdAsync(type.WalletId);

        wallet.CalculateNewBalance(financeOperation, oldType, oldAmount);

        _walletRepository.Update(wallet);
        await _unitOfWork.SaveChangesAsync();
    }
}
