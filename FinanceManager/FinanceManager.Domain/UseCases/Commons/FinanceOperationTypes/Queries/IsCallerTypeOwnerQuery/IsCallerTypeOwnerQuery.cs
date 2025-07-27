using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Queries.IsCallerTypeOwnerQuery;

public class IsCallerTypeOwnerQuery : IRequest<IResult<bool>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
