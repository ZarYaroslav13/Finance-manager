using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Roles.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Roles;

public interface IRoleService
{
    Task<Result<List<RoleDTO>>> GetAllAsync();

    Task<Result<RoleDTO>> GetByIdAsync(Guid id);
    Task<IResult> AddAsync(CreateRoleRequest request);

    Task<IResult> UpdateAsync(UpdateRoleRequest request);

    Task<IResult> DeleteAsync(Guid id);
}
