using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Users;

public interface IUserService
{
    Task<PaginatedResult<UserDTO>> GetAllAsync(int pageNumber, int pageSize);

    Task<Result<UserDTO>> GetAsync(Guid userId);

    Task<IResult> RegisterAsync(RegisterRequest request);

    Task<IResult<List<RoleDTO>>> GetUserRolesAsync(Guid id);

    Task<IResult> UpdateUserRolesAsync(UpdateUserRolesRequest request);

    Task<IResult<Guid>> ConfirmEmailAsync(Guid userId, string code);

    Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request);

    Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

    Task<IResult> DeleteUserAsync(Guid id);
}

