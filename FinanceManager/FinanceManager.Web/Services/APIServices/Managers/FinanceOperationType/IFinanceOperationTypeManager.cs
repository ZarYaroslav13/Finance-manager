using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperationType;

public interface IFinanceOperationTypeManager : IManager
{
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfWalletAsync(Guid walletId);

    public Task<Result<List<FinanceOperationTypeDTO>>> GetTypeAsync(Guid id);
    public Task<Result<FinanceOperationTypeDTO>> AddTypeAsync(AddFinanceOperationTypeCommand command);

    public Task<Result<FinanceOperationTypeDTO>> UpdateTypeAsync(UpdateFinanceOperationTypeCommand command);

    public Task<Domain.Wrapper.IResult> DeleteTypeAsync(Guid id);
}
