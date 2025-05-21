using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;

public class UpdateFinanceOperationTypeCommand : IRequest<Result<FinanceOperationTypeDTO>>
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
