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

namespace FinanceManager.Domain.UseCases.Wallets.Commands.CreateWalletCommand;

public class CreateWalletHandler : BaseRequestHandler, IRequestHandler<CreateWalletCommand, Result<WalletModel>>
{
    private readonly IRepository<Wallet> _repository;

    public CreateWalletHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<Result<WalletModel>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(_currentUserService.UserId == request.UserId.ToString()));

            var data = _mapper.Map<WalletModel>(
                _repository.Insert(
                    _mapper.Map<Wallet>(request)));

            await _unitOfWork.SaveChangesAsync();

            return Result<WalletModel>.Success(data, "Wallet created successfully");
        });
    }
}
