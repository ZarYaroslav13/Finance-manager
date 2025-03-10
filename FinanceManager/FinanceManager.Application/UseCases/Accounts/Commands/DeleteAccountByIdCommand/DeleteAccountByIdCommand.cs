using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : IRequest
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string UserRole { get; set; }

    [Required]
    public int Id { get; set; }
}
