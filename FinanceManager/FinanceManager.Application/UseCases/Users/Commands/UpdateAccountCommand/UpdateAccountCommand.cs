using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.UpdateCommand;

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
