using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;

public class UpdateAccountCommand : IRequest<BaseResponse<AccountDTO>>
{
    public int UserId { get; set; }

    public string UserRole { get; set; } = "";

    [Required]
    public int Id { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
