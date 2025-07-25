using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;

public class UpdateFinanceOperationTypeRequest
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public string Description { get; set; } = String.Empty;

    [Required]
    public EntryType EntryType { get; set; }

    [GuidRequired]
    public Guid WalletId { get; set; }

    public string WalletName { get; set; }
}
