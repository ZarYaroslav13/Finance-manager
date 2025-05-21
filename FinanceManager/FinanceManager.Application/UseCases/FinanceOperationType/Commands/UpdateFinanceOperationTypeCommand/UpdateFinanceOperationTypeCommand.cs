using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.UpdateFinanceOperationTypeCommand;

public class UpdateFinanceOperationTypeCommand : IRequest<Result<FinanceOperationTypeDTO>>
{
    [Required]
    public string Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public string Description { get; set; } = String.Empty;

    [Required]
    public EntryType EntryType { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public string WalletId { get; set; }

    public string WalletName { get; set; }
}
