using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;

public class DeleteUserCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
