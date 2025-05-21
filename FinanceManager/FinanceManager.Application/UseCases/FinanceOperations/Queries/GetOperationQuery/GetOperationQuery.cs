using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperations.Queries.GetOperationQuery;

public class GetOperationQuery : IRequest<Result<FinanceOperationDTO>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
