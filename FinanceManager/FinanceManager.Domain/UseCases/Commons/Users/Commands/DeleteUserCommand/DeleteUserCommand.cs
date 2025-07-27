using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Users.Commands.DeleteUserCommand;

public class DeleteUserCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
