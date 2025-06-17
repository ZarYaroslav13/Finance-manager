using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Application.UseCases.Users.Queries.GetAllUsersQuery;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinanceManager.Web.Services.APIServices.Managers.IUserManager;

public class UserManager : BaseManager, IUserManager
{
    public UserManager(
        IFinanceManagerApiHttpClient httpClient, ILogger<UserManager> logger) : base(httpClient, logger)
    {
    }

    public async Task<PaginatedResult<UserDTO>> GetAllAsync(GetAllUsersQuery query)
    {
        return await SendRequest(async () => await _apiHttpClient.GetAllUsersAsync(query.PageNumber, query.Take));
    }

    public async Task<IResult<UserDTO>> GetAsync(Guid userId)
    {
        return await SendRequest(async () => await _apiHttpClient.GetUserAsync(userId));
    }

    public async Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordCommand request)
    {
        return await SendRequest(async () => await _apiHttpClient.ForgotPasswordAsync(request));
    }
    public async Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordCommand request)
    {
        return await SendRequest(async () => await _apiHttpClient.ResetPasswordAsync(request));
    }

    public async Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterCommand request)
    {
        return await SendRequest(async () => await _apiHttpClient.RegisterUserAsync(request));
    }

    //public Task<Domain.Wrapper.IResult> ResendConfirmationMailAsync(string userId)
    //{
    //    var result = await _httpClient.ConfirmEmailAsync(request);

    //    return result;
    //}
}
