using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;

namespace FinanceManager.Domain.Services.Finances;

public class FinanceService : BaseService, IFinanceService
{
    private readonly IRepository<FinanceOperation> _financeOperationRepository;
    private readonly IRepository<FinanceOperationType> _financeOperationTypeRepository;

    public FinanceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _financeOperationRepository = _unitOfWork.GetRepository<FinanceOperation>();
        _financeOperationTypeRepository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    #region FinanceOperationTypeMethods

    public async Task<List<FinanceOperationTypeModel>> GetAllFinanceOperationTypesOfWalletAsync(Guid walletId)
    {
        return (await _financeOperationTypeRepository
                .GetAllAsync(filter: fot => fot.WalletId == walletId))
                .Select(_mapper.Map<FinanceOperationTypeModel>)
                .ToList();
    }

    public async Task<FinanceOperationTypeModel> AddFinanceOperationTypeAsync(FinanceOperationTypeModel type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (type.Id != Guid.Empty)
            throw new ArgumentException(nameof(type));

        var result = _financeOperationTypeRepository.Insert(
                             _mapper.Map<FinanceOperationType>(type));
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<FinanceOperationTypeModel>(result);
    }

    public async Task<FinanceOperationTypeModel> UpdateFinanceOperationTypeAsync(FinanceOperationTypeModel type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (type.Id == Guid.Empty)
            throw new ArgumentException(nameof(type));

        var result = _mapper.Map<FinanceOperationTypeModel>(
                         (_financeOperationTypeRepository.Update(
                            _mapper.Map<FinanceOperationType>(type))));
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task DeleteFinanceOperationTypeAsync(Guid id)
    {
        if ((await _financeOperationRepository.GetAllAsync(
                includeProperties: nameof(FinanceOperation.Type),
                filter: fo => fo.Type.Id == id))
            .Any())
        {
            throw new InvalidOperationException($"Deleting type with Id: {id} is imposible through operations with this type exists");
        }

        _financeOperationTypeRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }
    #endregion

    #region FinanceOperationMethods

    public async Task<List<FinanceOperationModel>> GetAllFinanceOperationOfWalletAsync(Guid walletId, int index = 0, int count = 0)
    {
        if (walletId <= Guid.Empty)
            throw new ArgumentOutOfRangeException(nameof(walletId));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        List<FinanceOperationModel> result = (await _financeOperationRepository
                .GetAllAsync(
                   includeProperties: nameof(FinanceOperation.Type),
                    filter: fo => fo.Type.WalletId == walletId,
                    orderBy: iQ => iQ.OrderBy(fo => fo.Date),
                    skip: index,
                    take: count))
                .Select(_mapper.Map<FinanceOperationModel>)
                .ToList();

        return result;
    }

    public async Task<List<FinanceOperationModel>> GetAllFinanceOperationOfWalletAsync(Guid walletId, DateTime startDate, DateTime endDate)
    {
        if (walletId <= Guid.Empty)
            throw new ArgumentException(nameof(walletId));

        ArgumentOutOfRangeException.ThrowIfGreaterThan(startDate, endDate);

        var dayAfterEndDate = endDate.AddDays(1);
        var dayBeforeStartDate = startDate.AddDays(-1);

        var result = (await _financeOperationRepository
                .GetAllAsync(
                includeProperties: nameof(FinanceOperation.Type),
                filter: fo =>
                       fo.Type.WalletId == walletId
                    && fo.Date <= dayAfterEndDate
                    && fo.Date >= dayBeforeStartDate))
                .Select(_mapper.Map<FinanceOperationModel>)
                .ToList();

        return result;
    }

    public async Task<List<FinanceOperationModel>> GetAllFinanceOperationOfTypeAsync(Guid typeId, int index = 0, int count = 0)
    {
        if (typeId <= Guid.Empty)
            throw new ArgumentOutOfRangeException(nameof(typeId));

        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));


        return (await _financeOperationRepository
                .GetAllAsync(
                    includeProperties: nameof(FinanceOperation.Type),
                    filter: fo => fo.Type.WalletId == typeId,
                    orderBy: iQ => iQ.OrderBy(fo => fo.Date),
                    skip: index,
                    take: count))
                .Select(_mapper.Map<FinanceOperationModel>)
                .ToList();
    }

    public async Task<FinanceOperationModel> AddFinanceOperationAsync(FinanceOperationModel financeOperation)
    {
        ArgumentNullException.ThrowIfNull(financeOperation);

        if (financeOperation.Id != Guid.Empty)
            throw new ArgumentException(nameof(financeOperation));

        if (await IsNotExistFinanceOperationTypeWithIdAsync(financeOperation.Type.Id))
            throw new InvalidOperationException("Finance operation type with this id don`t exist");

        var dbResult = _financeOperationRepository.Insert(
                _mapper.Map<FinanceOperation>(financeOperation));
        await _unitOfWork.SaveChangesAsync();

        dbResult.Type = await _financeOperationTypeRepository.GetByIdAsync(dbResult.TypeId);
        var result = _mapper.Map<FinanceOperationModel>(dbResult);

        return result;
    }

    public async Task<FinanceOperationModel> UpdateFinanceOperationAsync(FinanceOperationModel financeOperation)
    {
        ArgumentNullException.ThrowIfNull(financeOperation);

        if(financeOperation.Id == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(financeOperation.Id));
        var dbResult = _financeOperationRepository.Update(
                            _mapper.Map<FinanceOperation>(financeOperation));
        await _unitOfWork.SaveChangesAsync();

        dbResult.Type = await _financeOperationTypeRepository.GetByIdAsync(dbResult.TypeId);
        var result = _mapper.Map<FinanceOperationModel>(dbResult);

        return result;
    }

    public async Task DeleteFinanceOperationAsync(Guid id)
    {
        _financeOperationRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<bool> IsNotExistFinanceOperationTypeWithIdAsync(Guid id)
    {
        var type = await _financeOperationTypeRepository.GetByIdAsync(id);

        return type == null;
    }
    #endregion
}
