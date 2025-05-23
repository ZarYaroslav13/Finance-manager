using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Roles;

public interface IRoleService
{
    Task<Result<List<RoleModel>>> GetAllAsync();

    Task<Result<RoleModel>> GetByIdAsync(Guid id);
    Task<IResult> AddAsync(RoleModel request);

    Task<IResult> UpdateAsync(RoleModel request);

    Task<IResult> DeleteAsync(Guid id);
}
