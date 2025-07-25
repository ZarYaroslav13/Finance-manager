using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationHandler : BaseRequestHandler, IRequestHandler<DeleteFinanceOperationCommand, IResult>
{
    private readonly IRepository<FinanceOperation> _repository;
    private readonly IRepository<Wallet> _walletRepository;

    public DeleteFinanceOperationHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
        _walletRepository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<IResult> Handle(DeleteFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            var operation = await _repository.GetByIdAsync(request.Id);

            _repository.Delete(request.Id);

            await _unitOfWork.SaveChangesAsync();

            await UpdateWallet(operation);

            return Result.Success("Finance operation deleted successfully!");
        });
    }

    private async Task UpdateWallet(FinanceOperation operation)
    {
        var type = operation.Type;

        var wallet = await _walletRepository.GetByIdAsync(type.WalletId);

        if (type.EntryType == EntryType.Income)
            wallet.Balance -= (int)operation.Amount;
        else
            wallet.Balance += (int)operation.Amount;

        _walletRepository.Update(wallet);
        await _unitOfWork.SaveChangesAsync();
    }
}
