using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Roles.Queries.GetAllRolesQuery;

public class GetAllRolesQuery : IRequest<Result<List<RoleDTO>>>
{
}
