using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfWalletQuery;

public class GetAllOperationsOfWalletQuery : BaseRequest, IRequest<BaseResponse<List<FinanceOperationDTO>>>
{
    [Required]
    public int WalletId { get; set; }

    public int Index { get; set; } = 0;

    public int Count { get; set; } = 0;
}
