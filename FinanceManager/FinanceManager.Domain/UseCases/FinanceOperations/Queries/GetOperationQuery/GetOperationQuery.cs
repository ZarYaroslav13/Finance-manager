using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetOperationQuery;

public class GetOperationQuery : IRequest<Result<FinanceOperationModel>>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
