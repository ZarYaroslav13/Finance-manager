using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Queries.GetUserQuery;

public class GetUserQuery : IRequest<Result<UserDTO>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
