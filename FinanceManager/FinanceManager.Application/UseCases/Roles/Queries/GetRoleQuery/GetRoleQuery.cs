using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Roles.Queries.GetRoleQuery;

public class GetRoleQuery : IRequest<Result<RoleDTO>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
