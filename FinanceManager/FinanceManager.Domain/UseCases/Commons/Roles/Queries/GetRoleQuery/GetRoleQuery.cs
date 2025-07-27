using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Queries.GetRoleQuery;

public class GetRoleQuery : IRequest<Result<RoleModel>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
