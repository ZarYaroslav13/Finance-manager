using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Queries.GetFinanceOperationTypeQuery;

public class GetFinanceOperationTypeQuery : IRequest<Result<FinanceOperationTypeDTO>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
