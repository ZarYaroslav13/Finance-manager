using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.TokenManager;

public class TokenManager : ITokenManager
{
    private readonly IFinanceManagerApiHttpClient _httpClient;

    public TokenManager(IFinanceManagerApiHttpClient httpClient)
    {
        //_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task<Result<TokenDTO>> GetToken(GetTokenCommand command)
    {
        throw new NotImplementedException();
    }
}
