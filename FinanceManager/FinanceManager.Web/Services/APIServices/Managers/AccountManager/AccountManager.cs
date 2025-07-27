using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using FinanceManager.Web.Services.Autorization;

namespace FinanceManager.Web.Services.APIServices.Managers.IAccountManager
{
    public class AccountManager : BaseManager, IAccountManager
    {
        private readonly FinanceManagerStateProvider _stateProvider;
        public AccountManager(FinanceManagerStateProvider stateProvider,
            IFinanceManagerApiHttpClient httpClient, ILogger<AccountManager> logger) : base(httpClient, logger)
        {
            _stateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
        }

        public async Task<Domain.Wrapper.IResult> UpdateProfileAsync(UpdateAccountRequest model)
        {
            return await SendRequest(async () => await _apiHttpClient.UpdateAccountAsync(model));
        }

        public async Task<Domain.Wrapper.IResult> ChangePasswordAsync(ChangeAccountPasswordRequest model)
        {
            return await SendRequest(async () => await _apiHttpClient.ChangeAccountPasswordAsync(model));
        }
    }
}
