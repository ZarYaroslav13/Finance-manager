using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperationsType;

public interface IFinanceOperationsTypesManager : IManager
{
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfUserAsync(Guid userId);

    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfWalletAsync(Guid walletId);

    public Task<Result<List<FinanceOperationTypeDTO>>> GetTypeAsync(Guid id);
    public Task<Result<FinanceOperationTypeDTO>> AddTypeAsync(AddFinanceOperationTypeRequest request);

    public Task<Result<FinanceOperationTypeDTO>> UpdateTypeAsync(UpdateFinanceOperationTypeRequest request);

    public Task<Domain.Wrapper.IResult> DeleteTypeAsync(Guid id);
}
