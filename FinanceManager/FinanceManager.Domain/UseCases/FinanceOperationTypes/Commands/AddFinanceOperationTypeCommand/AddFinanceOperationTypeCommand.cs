using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;

public class AddFinanceOperationTypeCommand : IRequest<Result<FinanceOperationTypeModel>>
{
    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public string Description { get; set; } = String.Empty;

    [Required]
    public EntryType EntryType { get; set; }

    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
