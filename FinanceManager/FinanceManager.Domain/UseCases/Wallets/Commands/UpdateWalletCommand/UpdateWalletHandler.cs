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

namespace FinanceManager.Domain.UseCases.Wallets.Commands.UpdateWalletCommand;

public class UpdateWalletHandler : BaseRequestHandler, IRequestHandler<UpdateWalletCommand, Result<WalletModel>>
{
    private readonly IRepository<Wallet> _repository;

    public UpdateWalletHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<Result<WalletModel>> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request,
                () => request.IsUserOwner);

            var data = _mapper.Map<WalletModel>(
                            _repository.Update(
                                _mapper.Map<Wallet>(request)));

            await _unitOfWork.SaveChangesAsync();

            return Result<WalletModel>.Success(data, "Updated successfully");
        });
    }
}
