using FinanceManager.Application.Models.Base;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Application.Models.Requests.Users.Queries;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.IUserManager;

public class UserManager : BaseManager, IUserManager
{
    public UserManager(
        IFinanceManagerApiHttpClient httpClient, ILogger<UserManager> logger) : base(httpClient, logger)
    {
    }

    public async Task<PaginatedResult<UserDTO>> GetAllAsync(GetAllUsersRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.GetAllUsersAsync(request));
    }

    public async Task<IResult<UserDTO>> GetAsync(Guid userId)
    {
        return await SendRequest(async () => await _apiHttpClient.GetUserAsync(userId));
    }

    public async Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.ForgotPasswordAsync(request));
    }
    public async Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.ResetPasswordAsync(request));
    }

    public async Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.RegisterUserAsync(request));
    }

    //public Task<Domain.Wrapper.IResult> ResendConfirmationMailAsync(string userId)
    //{
    //    var result = await _httpClient.ConfirmEmailAsync(request);

    //    return result;
    //}
}
