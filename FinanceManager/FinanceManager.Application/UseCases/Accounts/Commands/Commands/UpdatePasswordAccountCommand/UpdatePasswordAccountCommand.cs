using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;

public class UpdatePasswordAccountCommand : IRequest<Result<AccountDTO>>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}
