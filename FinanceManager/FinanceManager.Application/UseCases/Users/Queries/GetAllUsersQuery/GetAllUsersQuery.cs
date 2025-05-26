using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Queries.GetAllUsersQuery;

public class GetAllUsersQuery : IRequest<PaginatedResult<UserDTO>>
{
    public int PageNumber { get; set; } = 0;

    public int Take { get; set; } = 0;
}
