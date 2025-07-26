using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Users.Commands.DeleteAccountByIdCommand;

public class DeleteUserCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
