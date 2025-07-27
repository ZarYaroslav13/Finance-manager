using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Commands.UpdateRoleCommand;

public class UpdateRoleCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
