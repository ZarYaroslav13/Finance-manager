using System.Diagnostics;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Users;

public interface IUserService
{
    Task<List<UserModel>> GetAllAsync();

    Task<UserModel> GetAsync(string userId);

    Task<IResult> RegisterAsync(UserModel model, string password, string origin);

    Task<IResult<UserRoleModel>> GetRolesAsync(Guid id);

    Task<IResult> UpdateRolesAsync(Guid id, List<UserRoleModel> roles);

    Task<IResult<string>> ConfirmEmailAsync(Guid userId, string code);

    Task<IResult> ForgotPasswordAsync(string email, string origin);

    Task<IResult> ResetPasswordAsync(string email, string password, string token);

    Task<string> ExportToExcelAsync(string searchString = "");
}
}
