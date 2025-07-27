using FinanceManager.Domain.DataAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
