using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;
using FinanceManager.Infrastructure.UnitOfWork;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Domain.Extentions;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;

public class UpdateFinanceOperationTypeHandler : BaseRequestHandler, IRequestHandler<UpdateFinanceOperationTypeCommand, Result<FinanceOperationTypeModel>>
{
    private readonly IRepository<FinanceOperationType> _repository;
    private readonly IRepository<Wallet> _walletRepository;
    public UpdateFinanceOperationTypeHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
        _walletRepository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<Result<FinanceOperationTypeModel>> Handle(UpdateFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            if (request.Id == Guid.Empty)
                throw new ArgumentException(nameof(request.Id));

            var oldType = _mapper.Map<FinanceOperationTypeModel>(
                            await _repository.GetByIdAsync(request.Id));

            var data = _mapper.Map<FinanceOperationTypeModel>(
                             (_repository.Update(
                                _mapper.Map<FinanceOperationType>(request))));
            await _unitOfWork.SaveChangesAsync();

            if (oldType.EntryType != data.EntryType)
            {
                await EntryTypeChanged(oldType, data);
            }

            if (oldType.WalletId != data.WalletId)
            {
                await WalletChanged(oldType, data);
            }

            return Result<FinanceOperationTypeModel>.Success(data, "Finance operation type updated successfully!");
        });
    }

    private async Task EntryTypeChanged(FinanceOperationTypeModel oldType, FinanceOperationTypeModel type)
    {
        var wallet = await _walletRepository.GetByIdAsync(type.WalletId);
        var operations = await GetAllFinanceOperationOfTypeAsync(type.Id);

        foreach (var operation in operations)
        {
            wallet.CalculateNewBalance(operation, oldType.EntryType, (int)operation.Amount);
        }


        _walletRepository.Update(wallet);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task WalletChanged(FinanceOperationTypeModel oldType, FinanceOperationTypeModel type)
    {
        var oldWallet = await _walletRepository.GetByIdAsync(oldType.WalletId);
        var newWallet = await _walletRepository.GetByIdAsync(type.WalletId);
        var operations = await GetAllFinanceOperationOfTypeAsync(type.Id);

        var modificator = (oldType.EntryType == EntryType.Income) ? 1 : -1;

        foreach (var operation in operations)
        {
            newWallet.Balance += modificator * (int)operation.Amount;
            oldWallet.Balance -= modificator * (int)operation.Amount;
        }

        _walletRepository.Update(newWallet);
        _walletRepository.Update(oldWallet);

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<List<FinanceOperation>> GetAllFinanceOperationOfTypeAsync(Guid id, int index = 0, int count = 0)
    {
        var operationRepository = _unitOfWork.GetRepository<FinanceOperation>();

        var list = (await operationRepository
                .GetAllAsync(
                    includeProperties: nameof(FinanceOperation.Type),
                    filter: fo => fo.Type.Id == id,
                    orderBy: iQ => iQ.OrderBy(fo => fo.Date),
                    skip: index,
                    take: count))
                .ToList();

        return list;
    }
}
