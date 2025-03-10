using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : IRequest<BaseResponse<bool>>
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string UserRole { get; set; }

    [Required]
    public int Id { get; set; }
}
