using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Accounts.Commands.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
