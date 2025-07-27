using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Account.Commands;

public class ChangeAccountPasswordRequest
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

    [Required]
    [Compare(nameof(NewPassword))]
    public string ConfirmNewPassword { get; set; }
}
