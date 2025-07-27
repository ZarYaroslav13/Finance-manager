using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperationsType
{
    public class FinanceOperationsTypesManager : BaseManager, IFinanceOperationsTypesManager
    {
        public FinanceOperationsTypesManager(IFinanceManagerApiHttpClient httpClient,
            ILogger<FinanceOperationsTypesManager> logger) : base(httpClient, logger)
        {
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfUserAsync(Guid userId)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllUserFinanceOperationTypesAsync(userId));
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfWalletAsync(Guid walletId)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllFinanceOperationTypesOfWalletAsync(walletId));
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetTypeAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllFinanceOperationTypesOfWalletAsync(id));
        }

        public async Task<Result<FinanceOperationTypeDTO>> AddTypeAsync(AddFinanceOperationTypeRequest request)
        {
            return await SendRequest(async () => await _apiHttpClient.AddFinanceOperationTypeAsync(request));
        }

        public async Task<Result<FinanceOperationTypeDTO>> UpdateTypeAsync(UpdateFinanceOperationTypeRequest request)
        {
            return await SendRequest(async () => await _apiHttpClient.UpdateFinanceOperationTypeAsync(request));
        }


        public async Task<Domain.Wrapper.IResult> DeleteTypeAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.DeleteFinanceOperationTypeAsync(id));
        }
    }
}
