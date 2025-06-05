using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.IAccountManager
{
    public class AccountManager : BaseManager, IAccountManager
    {
        public AccountManager(IFinanceManagerApiHttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Domain.Wrapper.IResult> ChangePasswordAsync(ChangeUserPasswordCommand model)
        {
            var result = await _httpClient.ChangeAccountPasswordAsync(model);

            return result;
        }

        public async Task<Domain.Wrapper.IResult> UpdateProfileAsync(UpdateAccountCommand model)
        {
            var result = await _httpClient.UpdateAccountAsync(model);

            return result;
        }
    }
}
