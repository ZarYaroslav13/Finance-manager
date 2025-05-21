using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfTypeQuery;

public class GetAllOperationsOfTypeQuery : IRequest<Result<List<FinanceOperationDTO>>>
{
    [Required]
    public string TypeId { get; set; }

    public int Index { get; set; } = 0;

    public int Count { get; set; } = 0;
}
