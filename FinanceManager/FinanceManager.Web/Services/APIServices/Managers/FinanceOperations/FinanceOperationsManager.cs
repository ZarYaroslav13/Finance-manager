using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
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

        public async Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfWalletAsync(GetAllOperationsOfWalletRequest request)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllOfWalletAsync(request));
        }

        public async Task<Result<List<FinanceOperationDTO>>> GetAllOperationsOfTypeAsync(GetAllOperationsOfTypeRequest request)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllFinanceOperationsOfTypeAsync(request));
        }

        public async Task<Result<FinanceOperationDTO>> GetOperationAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.GetFinanceOperationAsync(id));
        }

        public async Task<Result<FinanceOperationDTO>> AddOperationAsync(AddFinanceOperationRequest request)
        {
            return await SendRequest(async () => await _apiHttpClient.AddFinanceOperationAsync(request));
        }

        public async Task<Result<FinanceOperationDTO>> UpdateOperationAsync(UpdateFinanceOperationRequest request)
        {
            return await SendRequest(async () => await _apiHttpClient.UpdateFinanceOperationAsync(request));
        }

        public async Task<Domain.Wrapper.IResult> DeleteOperationAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.DeleteFinanceOperationAsync(id));
        }
    }
}
