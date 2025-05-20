using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;

namespace FinanceManager.Domain.Services.Wallets;

public class WalletService : BaseService, IWalletService
{
    private readonly IRepository<Wallet> _repository;

    public WalletService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<List<WalletModel>> GetAllWalletsOfAccountAsync(Guid accountId)
    {
        return (await _repository
            .GetAllAsync(filter: w => w.AccountId == accountId))
            .Select(_mapper.Map<WalletModel>)
            .ToList();
    }

    public async Task<WalletModel> AddWalletAsync(WalletModel wallet)
    {
        ArgumentNullException.ThrowIfNull(wallet);

        if (wallet.Id != Guid.Empty)
            throw new ArgumentException(nameof(wallet));

        if (wallet.AccountId <= 0)
            throw new ArgumentOutOfRangeException(nameof(wallet));

        var result = _repository.Insert(
                                _mapper.Map<Wallet>(wallet));
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<WalletModel>(result);
    }

    public async Task<WalletModel> UpdateWalletAsync(WalletModel updatedWallet)
    {
        ArgumentNullException.ThrowIfNull(updatedWallet);

        if (updatedWallet.Id == Guid.Empty)
            throw new ArgumentException(nameof(updatedWallet));

        var result = _mapper.Map<WalletModel>(
                        _repository.Update(
                            _mapper.Map<Wallet>(updatedWallet)));
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task DeleteWalletByIdAsync(Guid id)
    {
        _repository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<WalletModel> FindWalletAsync(Guid id)
    {
        return _mapper
            .Map<WalletModel>(
               await _repository.GetByIdAsync(id));
    }
}
