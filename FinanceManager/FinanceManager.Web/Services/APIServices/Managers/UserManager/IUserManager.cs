using FinanceManager.Application.Models.Base;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Application.Models.Requests.Users.Queries;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.IUserManager;

public interface IUserManager : IManager
{
    Task<PaginatedResult<UserDTO>> GetAllAsync(GetAllUsersRequest request);

    Task<Domain.Wrapper.IResult<UserDTO>> GetAsync(Guid userId);

    Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordRequest request);

    Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordRequest request);

    Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterRequest request);

    //Task<Domain.Wrapper.IResult> ResendConfirmationMailAsync(string userId);
}
