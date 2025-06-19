using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Queries.GetAllUserFinanceOperationTypesQuery;

public class GetAllUserFinanceOperationTypesQuery : IRequest<Result<List<FinanceOperationTypeDTO>>>
{
    [GuidRequired]
    public Guid userId { get; set; }
}
