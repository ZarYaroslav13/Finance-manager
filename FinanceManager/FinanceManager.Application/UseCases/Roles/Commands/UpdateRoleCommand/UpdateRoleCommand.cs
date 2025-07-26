using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Roles.Commands.UpdateRoleCommand;

public class UpdateRoleCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
