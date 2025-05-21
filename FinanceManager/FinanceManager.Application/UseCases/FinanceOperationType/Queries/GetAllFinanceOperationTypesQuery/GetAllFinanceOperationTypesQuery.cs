using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Queries.GetAllFinanceOperationTypesQuery;

public class GetAllFinanceOperationTypesQuery : IRequest<Result<List<FinanceOperationTypeDTO>>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }
}
