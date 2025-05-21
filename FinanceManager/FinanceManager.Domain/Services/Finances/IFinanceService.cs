using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.Services.Finances;

public interface IFinanceService
{
    public Task<List<FinanceOperationTypeModel>> GetAllFinanceOperationTypesOfWalletAsync(Guid walletId);

    public Task<FinanceOperationTypeModel> AddFinanceOperationTypeAsync(FinanceOperationTypeModel type);

    public Task<FinanceOperationTypeModel> UpdateFinanceOperationTypeAsync(FinanceOperationTypeModel type);

    public Task DeleteFinanceOperationTypeAsync(Guid id);

    public Task<bool> IsCallerFinanceOperationTypeOwner(Guid typeId);

    public Task<List<FinanceOperationModel>> GetAllFinanceOperationOfWalletAsync(Guid walletId, int index = 0, int count = 0);

    public Task<List<FinanceOperationModel>> GetAllFinanceOperationOfWalletAsync(Guid walletId, DateTime startDate, DateTime endDate);

    public Task<List<FinanceOperationModel>> GetAllFinanceOperationOfTypeAsync(Guid typeId, int index = 0, int count = 0);

    public Task<FinanceOperationModel> AddFinanceOperationAsync(FinanceOperationModel financeOperation);

    public Task<FinanceOperationModel> UpdateFinanceOperationAsync(FinanceOperationModel financeOperation);

    public Task DeleteFinanceOperationAsync(Guid id);

    public Task<bool> IsCallerFinanceOperationOperationOwner(Guid operationId);
}
