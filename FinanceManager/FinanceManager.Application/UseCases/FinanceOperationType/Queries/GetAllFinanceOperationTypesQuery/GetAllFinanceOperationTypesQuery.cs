using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Queries.GetAllFinanceOperationTypesQuery;

public class GetAllFinanceOperationTypesQuery : IRequest<Result<List<FinanceOperationTypeDTO>>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }
}
