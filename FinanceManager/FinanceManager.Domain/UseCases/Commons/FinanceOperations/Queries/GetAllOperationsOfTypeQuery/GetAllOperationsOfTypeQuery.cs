using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperations.Queries.GetAllOperationsOfTypeQuery;

public class GetAllOperationsOfTypeQuery : IRequest<Result<List<FinanceOperationModel>>>
{
    [GuidRequired]
    public Guid TypeId { get; set; }

    [Range(0, int.MaxValue)]
    public int Index { get; set; } = 0;

    [Range(0, int.MaxValue)]
    public int Count { get; set; } = 0;

    [Required]
    public bool IsCallerOwner { get; set; }
}
