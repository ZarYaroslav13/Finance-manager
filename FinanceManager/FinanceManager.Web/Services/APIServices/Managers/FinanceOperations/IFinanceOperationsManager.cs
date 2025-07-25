using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperations;

public interface IFinanceOperationsManager : IManager
{
    public Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfWalletAsync(Guid walletId, int index = 0, int take = 0);

    public Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfTypeAsync(Guid typeId, int index = 0, int take = 0);

    public Task<Result<FinanceOperationDTO>> GetOperationAsync(Guid id);

    public Task<Result<FinanceOperationDTO>> AddOperationAsync(AddFinanceOperationCommand command);

    public Task<Result<FinanceOperationDTO>> UpdateOperationAsync(UpdateFinanceOperationCommand command);

    public Task<Domain.Wrapper.IResult> DeleteOperationAsync(Guid id);
}
