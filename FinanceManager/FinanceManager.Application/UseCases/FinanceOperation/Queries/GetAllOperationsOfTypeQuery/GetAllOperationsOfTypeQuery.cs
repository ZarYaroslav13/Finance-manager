using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperations.Queries.GetAllOperationsOfTypeQuery;

public class GetAllOperationsOfTypeQuery : IRequest<Result<List<FinanceOperationDTO>>>
{
    [GuidRequired]
    public Guid TypeId { get; set; }

    public int Index { get; set; } = 0;

    public int Count { get; set; } = 0;
}
