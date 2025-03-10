using FinanceManager.Application.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;

public class GetAllCustomersQuery : IRequest<List<AccountDTO>>
{
    public ClaimsIdentity? Identity { get; set; }

    public int skip { get; set; } = 0;

    public int take { get; set; } = 0;
}
