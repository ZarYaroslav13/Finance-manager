using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using Infrastructure.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.UpdateFinanceOperationTypeCommand;

public class UpdateFinanceOperationTypeCommand : BaseRequest, IRequest<BaseResponse<FinanceOperationTypeDTO>>
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public string Description { get; set; } = String.Empty;

    [Required]
    public EntryType EntryType { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int WalletId { get; set; }

    public string WalletName { get; set; }
}
