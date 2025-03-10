using FinanceManager.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;

public class UpdatePasswordAccountCommand : IRequest<AccountDTO>
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string UserRole { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}
