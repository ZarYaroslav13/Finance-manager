using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;

public class GetAllOperationsOfWalletQuery : IRequest<Result<List<FinanceOperationModel>>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Range(0, int.MaxValue)]
    public int Index { get; set; } = 0;

    [Range(0, int.MaxValue)]
    public int Count { get; set; } = 0;

    [Required]
    public bool IsCallerOwner { get; set; }
}
