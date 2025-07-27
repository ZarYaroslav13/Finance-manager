using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.Wallets.Commands.DeleteWalletCommand;

public class DeleteWalletHandler : BaseRequestHandler, IRequestHandler<DeleteWalletCommand, IResult>
{
    private readonly IRepository<Wallet> _repository;

    public DeleteWalletHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<IResult> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {

            CheckIsUserHaveAccesToResourse(request,
               () => request.IsUserOwner);

            _repository.Delete(request.WalletId);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Deleted wallet successfully!");
        });
    }
}
