using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Queries.GetAllRolesQuery;

public class GetAllRolesQuery : IRequest<Result<List<RoleModel>>>
{
}
