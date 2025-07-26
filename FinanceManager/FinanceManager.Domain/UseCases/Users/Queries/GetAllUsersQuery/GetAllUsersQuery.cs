using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Users.Queries.GetAllUsersQuery;

public class GetAllUsersQuery : IRequest<PaginatedResult<UserModel>>
{
    public int PageNumber { get; set; } = 0;

    public int Take { get; set; } = 0;
}
