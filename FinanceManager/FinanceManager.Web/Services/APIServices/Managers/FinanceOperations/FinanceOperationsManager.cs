using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.AddFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperations
{
    public class FinanceOperationsManager : BaseManager, IFinanceOperationsManager
    {
        public FinanceOperationsManager(IFinanceManagerApiHttpClient httpClient,
            ILogger<FinanceOperationsManager> logger) : base(httpClient, logger)
        {
        }

        public async Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfWalletAsync(Guid walletId, int index = 0, int take = 0)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllOfWalletAsync(walletId, index, take));
        }

        public async Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfTypeAsync(Guid typeId, int index = 0, int take = 0)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllFinanceOperationsOfTypeAsync(typeId, index, take));
        }

        public async Task<Result<FinanceOperationDTO>> GetOperationAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.GetFinanceOperationAsync(id));
        }

        public async Task<Result<FinanceOperationDTO>> AddOperationAsync(AddFinanceOperationCommand command)
        {
            return await SendRequest(async () => await _apiHttpClient.AddFinanceOperationAsync(command));
        }

        public async Task<Result<FinanceOperationDTO>> UpdateOperationAsync(UpdateFinanceOperationCommand command)
        {
            return await SendRequest(async () => await _apiHttpClient.UpdateFinanceOperationAsync(command));
        }

        public async Task<Domain.Wrapper.IResult> DeleteOperationAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.DeleteFinanceOperationAsync(id));
        }
    }
}
