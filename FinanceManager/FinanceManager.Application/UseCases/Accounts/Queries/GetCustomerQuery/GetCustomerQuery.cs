using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetCustomerQuery;

public class GetCustomerQuery : BaseRequest, IRequest<BaseResponse<AccountDTO>>
{
    public int Id { get; set; }
}
