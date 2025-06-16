using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using FinanceManager.Web.Services.Autorization;

namespace FinanceManager.Web.Services.APIServices.Managers.IAccountManager
{
    public class AccountManager : BaseManager, IAccountManager
    {
        private readonly FinanceManagerStateProvider _stateProvider;
        public AccountManager(IFinanceManagerApiHttpClient httpClient, FinanceManagerStateProvider stateProvider) : base(httpClient)
        {
            _stateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
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
