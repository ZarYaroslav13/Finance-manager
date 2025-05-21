using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Queries.GetAllFinanceOperationTypesQuery;

public class GetAllFinanceOperationTypesQuery : BaseRequest, IRequest<BaseResponse<List<FinanceOperationTypeDTO>>>
{
    public int WalletId { get; set; }
}
