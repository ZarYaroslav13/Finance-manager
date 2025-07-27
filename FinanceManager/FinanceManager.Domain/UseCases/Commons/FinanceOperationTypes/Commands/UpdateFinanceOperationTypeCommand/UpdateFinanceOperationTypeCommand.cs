using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;

public class UpdateFinanceOperationTypeCommand : IRequest<Result<FinanceOperationTypeModel>>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public string Description { get; set; } = string.Empty;

    [Required]
    public EntryType EntryType { get; set; }

    [GuidRequired]
    public Guid WalletId { get; set; }

    public string WalletName { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
