using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Queries.GetCustomerQuery;

public class GetCustomerQuery : BaseRequest, IRequest<BaseResponse<AccountDTO>>
{
    public int Id { get; set; }
}
