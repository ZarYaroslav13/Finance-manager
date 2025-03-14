using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;

public class GetAllCustomersQuery : BaseRequest, IRequest<BaseResponse<List<AccountDTO>>>
{
    public int skip { get; set; } = 0;

    public int take { get; set; } = 0;
}
