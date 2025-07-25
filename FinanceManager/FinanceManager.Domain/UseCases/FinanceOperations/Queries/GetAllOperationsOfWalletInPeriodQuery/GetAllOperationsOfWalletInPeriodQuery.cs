using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletInPeriodQuery;

public class GetAllOperationsOfWalletInPeriodQuery : IRequest<Result<List<FinanceOperationModel>>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
