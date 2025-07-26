using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Users.Queries.GetUserQuery;

public class GetUserQuery : IRequest<Result<UserModel>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
