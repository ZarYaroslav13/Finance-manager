using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
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

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(GetAllOperationsOfWalletRequest request);

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfWalletAsync(GetAllOperationsOfWalletInPeriodRequest request);

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationOfTypeAsync(GetAllOperationsOfTypeRequest request);

    public Task<Result<FinanceOperationDTO>> GetFinanceOperation(Guid id);

    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync(AddFinanceOperationRequest request);

    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync(UpdateFinanceOperationRequest request);

    public Task<IResult> DeleteFinanceOperationAsync(Guid id);
}
