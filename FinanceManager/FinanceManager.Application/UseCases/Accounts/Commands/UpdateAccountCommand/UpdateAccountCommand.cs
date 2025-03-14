using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;

public class UpdateAccountCommand : BaseRequest, IRequest<BaseResponse<AccountDTO>>
{
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
