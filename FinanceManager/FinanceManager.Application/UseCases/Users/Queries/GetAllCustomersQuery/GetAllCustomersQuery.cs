using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Queries.GetAllCustomersQuery;

public class GetAllCustomersQuery : BaseRequest, IRequest<BaseResponse<List<AccountDTO>>>
{
    public int skip { get; set; } = 0;

    public int take { get; set; } = 0;
}
