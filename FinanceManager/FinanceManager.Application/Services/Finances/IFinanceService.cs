using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Finances;

public interface IFinanceService
{
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllUserFinanceOperationTypesAsync(Guid userId);

    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesOfWalletAsync(Guid walletId);

    public Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationType(Guid id);

    public Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync(AddFinanceOperationTypeRequest request);

    public Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync(UpdateFinanceOperationTypeRequest request);

    public Task<IResult> DeleteFinanceOperationTypeAsync(Guid id);

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(Guid walletId, int index = 0, int count = 0);

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(Guid walletId, DateTime startDate, DateTime endDate);

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfTypeAsync(Guid typeId, int index = 0, int count = 0);

    public Task<Result<FinanceOperationDTO>> GetFinanceOperation(Guid id);

    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync(FinanceOperationDTO financeOperation);

    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync(FinanceOperationDTO financeOperation);

    public Task<IResult> DeleteFinanceOperationAsync(Guid id);
}
