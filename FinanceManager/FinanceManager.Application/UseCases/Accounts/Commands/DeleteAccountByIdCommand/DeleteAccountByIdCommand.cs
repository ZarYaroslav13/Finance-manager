using MediatR;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : IRequest
{
    public ClaimsIdentity? Identity { get; set; }

    public int Id { get; set; }
}
