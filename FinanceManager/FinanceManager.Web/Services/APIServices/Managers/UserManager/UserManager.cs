using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Application.UseCases.Users.Queries.GetAllUsersQuery;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.IUserManager;

public class UserManager : BaseManager, IUserManager
{
    public UserManager(IFinanceManagerApiHttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<PaginatedResult<UserDTO>> GetAllAsync(GetAllUsersQuery query)
    {
        var result = await _httpClient.GetAllUsersAsync(query.PageNumber, query.Take);

        return result;
    }

    public async Task<IResult<UserDTO>> GetAsync(string userId)
    {
        var result = await _httpClient.GetUserAsync(new Guid(userId));

        return result;
    }

    public async Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordCommand request)
    {
        var result = await _httpClient.ForgotPasswordAsync(request);

        return result;
    }
    public async Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordCommand request)
    {
        var result = await _httpClient.ResetPasswordAsync(request);

        return result;
    }

    public async Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterCommand request)
    {
        var result = await _httpClient.RegisterUserAsync(request);

        return result;
    }

    //public Task<Domain.Wrapper.IResult> ResendConfirmationMailAsync(string userId)
    //{
    //    var result = await _httpClient.ConfirmEmailAsync(request);

    //    return result;
    //}
}
