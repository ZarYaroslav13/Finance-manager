using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Queries.GetAllFinanceOperationTypesQuery;

public class GetAllFinanceOperationTypesQuery : BaseRequest, IRequest<BaseResponse<List<FinanceOperationTypeDTO>>>
{
    public int WalletId { get; set; }
}
