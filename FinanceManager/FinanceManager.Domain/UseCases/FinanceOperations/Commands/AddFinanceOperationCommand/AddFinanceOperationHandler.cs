using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Commands.AddFinanceOperationCommand;

public class AddFinanceOperationHandler : BaseRequestHandler, IRequestHandler<AddFinanceOperationCommand, IResult<FinanceOperationModel>>
{
    private readonly IRepository<FinanceOperation> _repository;
    private readonly IRepository<FinanceOperationType> _financeOperationTypeRepository;

    public AddFinanceOperationHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
        _financeOperationTypeRepository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    public async Task<IResult<FinanceOperationModel>> Handle(AddFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            if (await IsNotExistFinanceOperationTypeWithIdAsync(request.TypeId))
                throw new InvalidOperationException("Finance operation type with this id don`t exist");

            var dbResult = _repository.Insert(
                    _mapper.Map<FinanceOperation>(request));
            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<FinanceOperationModel>(dbResult);

            await UpdateWalletAfterCreatingOperation(data);

            return await Result<FinanceOperationModel>.SuccessAsync(data, "Finance operation created successfully!");
        });
    }

    private async Task<bool> IsNotExistFinanceOperationTypeWithIdAsync(Guid id)
    {
        var type = await _financeOperationTypeRepository.GetByIdAsync(id);

        return type == null;
    }

    private async Task UpdateWalletAfterCreatingOperation(FinanceOperationModel financeOperation)
    {
        var walletRepository = _unitOfWork.GetRepository<Wallet>();
        var type = financeOperation.Type;
        var wallet = await walletRepository.GetByIdAsync(type.WalletId);

        if (type.EntryType == EntryType.Income)
            wallet.Balance += financeOperation.Amount;
        else
            wallet.Balance -= financeOperation.Amount;

        walletRepository.Update(wallet);

        await _unitOfWork.SaveChangesAsync();
    }
}
