using FinanceManager.Domain.Models;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Users;

public interface IUserService
{
    Task<Result<List<UserModel>>> GetAllAsync();

    Task<Result<UserModel>> GetAsync(Guid userId);

    Task<IResult> RegisterAsync(UserModel model, string password);

    Task<IResult<List<UserRoleModel>>> GetRolesAsync(Guid id);

    Task<IResult> UpdateRolesAsync(Guid id, List<UserRoleModel> newRroles);

    Task<IResult<Guid>> ConfirmEmailAsync(Guid userId, string code);

    Task<IResult> ForgotPasswordAsync(string email, string origin);

    Task<IResult> ResetPasswordAsync(string email, string password, string token);

    Task<IResult> DeleteUserAsync(Guid id);
}

