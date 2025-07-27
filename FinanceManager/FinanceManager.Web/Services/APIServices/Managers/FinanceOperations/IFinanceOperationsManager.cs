using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperations;

public interface IFinanceOperationsManager : IManager
{
    public Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfWalletAsync(GetAllOperationsOfWalletRequest request);

    public Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfTypeAsync(GetAllOperationsOfTypeRequest request);

    public Task<Result<FinanceOperationDTO>> GetOperationAsync(Guid id);

    public Task<Result<FinanceOperationDTO>> AddOperationAsync(AddFinanceOperationRequest request);

    public Task<Result<FinanceOperationDTO>> UpdateOperationAsync(UpdateFinanceOperationRequest request);

    public Task<Domain.Wrapper.IResult> DeleteOperationAsync(Guid id);
}
