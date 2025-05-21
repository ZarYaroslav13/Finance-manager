using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfTypeQuery;

public class GetAllOperationsOfTypeQuery : BaseRequest, IRequest<BaseResponse<List<FinanceOperationDTO>>>
{
    [Required]
    public int TypeId { get; set; }

    public int Index { get; set; } = 0;

    public int Count { get; set; } = 0;
}
