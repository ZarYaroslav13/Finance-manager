using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.IUserManager;

public interface IUserManager : IManager
{
    Task<PaginatedResult<UserDTO>> GetAllAsync(GetAllUsersQuery query);

    Task<Domain.Wrapper.IResult<UserDTO>> GetAsync(Guid userId);

    Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordCommand request);

    Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordCommand request);

    Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterCommand request);

    //Task<Domain.Wrapper.IResult> ResendConfirmationMailAsync(string userId);
}
