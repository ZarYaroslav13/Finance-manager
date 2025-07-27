using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Commands.DeleteRoleCommand;

public class DeleteRoleCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
