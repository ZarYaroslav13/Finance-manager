using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Wallets.Commands;

public class CreateWalletRequest
{
    [GuidRequired]
    public Guid UserId { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public int Balance { get; set; }
}
