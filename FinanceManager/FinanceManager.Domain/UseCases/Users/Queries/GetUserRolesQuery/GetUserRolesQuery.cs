using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Users.Queries.GetUserRolesQuery;

public class GetUserRolesQuery : IRequest<Result<List<UserRoleModel>>>
{
    [GuidRequired]
    public Guid UserId { get; set; }
}
