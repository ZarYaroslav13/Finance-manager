using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Roles.Commands.DeleteRoleCommand;

public class DeleteRoleCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
