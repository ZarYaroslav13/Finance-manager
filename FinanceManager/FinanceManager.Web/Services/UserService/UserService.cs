using FinanceManager.Application.Security;
using FinanceManager.Application.UseCases.Login.Commands.SignInCommand;
using FinanceManager.Web.API;
using System.Security.Claims;

namespace FinanceManager.Web.Services.UserService;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<User?> SendAuthenticateRequestAsync(SignInCommand command)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Login.SignIn, command);

        if(response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
        }

        return new();
    }

    private ClaimsPrincipal CreateClaimsPrincipalFromToken(string token)
    {
        return new();
    }
}
