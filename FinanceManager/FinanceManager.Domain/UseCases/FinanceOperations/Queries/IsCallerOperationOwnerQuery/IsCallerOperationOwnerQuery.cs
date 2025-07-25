using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.IsCallerOperationOwnerQuery;

public class IsCallerOperationOwnerQuery : IRequest<IResult<bool>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
