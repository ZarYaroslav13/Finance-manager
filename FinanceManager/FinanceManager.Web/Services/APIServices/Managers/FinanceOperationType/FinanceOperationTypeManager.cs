using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceOperationType
{
    public class FinanceOperationTypeManager : BaseManager, IFinanceOperationTypeManager
    {
        public FinanceOperationTypeManager(IFinanceManagerApiHttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetAllTypesOfWalletAsync(Guid walletId)
        {
            return await _httpClient.GetAllFinanceOperationTypesAsync(walletId);
        }

        public async Task<Result<List<FinanceOperationTypeDTO>>> GetTypeAsync(Guid id)
        {
            return await _httpClient.GetAllFinanceOperationTypesAsync(id);
        }

        public async Task<Result<FinanceOperationTypeDTO>> AddTypeAsync(AddFinanceOperationTypeCommand command)
        {
            return await _httpClient.AddFinanceOperationTypeAsync(command);
        }

        public async Task<Result<FinanceOperationTypeDTO>> UpdateTypeAsync(UpdateFinanceOperationTypeCommand command)
        {
            return await _httpClient.UpdateFinanceOperationTypeAsync(command);
        }


        public async Task<Result> DeleteTypeAsync(Guid id)
        {
            return await _httpClient.DeleteFinanceOperationTypeAsync(id);
        }
    }
}
