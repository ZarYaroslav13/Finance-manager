using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperationType
{
    public class FinanceOperationTypeManager : BaseManager, IFinanceOperationTypeManager
    {
        public FinanceOperationTypeManager(IFinanceManagerApiHttpClient httpClient,
            ILogger<FinanceOperationTypeManager> logger) : base(httpClient, logger)
        {
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfWalletAsync(Guid walletId)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllFinanceOperationTypesAsync(walletId));
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetTypeAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.GetAllFinanceOperationTypesAsync(id));
        }

        public async Task<Result<FinanceOperationTypeDTO>> AddTypeAsync(AddFinanceOperationTypeCommand command)
        {
            return await SendRequest(async () => await _apiHttpClient.AddFinanceOperationTypeAsync(command));
        }

        public async Task<Result<FinanceOperationTypeDTO>> UpdateTypeAsync(UpdateFinanceOperationTypeCommand command)
        {
            return await SendRequest(async () => await _apiHttpClient.UpdateFinanceOperationTypeAsync(command));
        }


        public async Task<Domain.Wrapper.IResult> DeleteTypeAsync(Guid id)
        {
            return await SendRequest(async () => await _apiHttpClient.DeleteFinanceOperationTypeAsync(id));
        }
    }
}
