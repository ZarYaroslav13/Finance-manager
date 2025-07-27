using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Queries.GetWalletFinanceOperationTypesQuery;

public class GetWalletFinanceOperationTypesQuery : IRequest<Result<List<FinanceOperationTypeModel>>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
