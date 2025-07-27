using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Users.Queries.ConfirmEmailQuery;

public class ConfirmEmailQuery : IRequest<IResult<Guid>>
{
    [GuidRequired]
    public Guid UserId { get; set; }

    [Required]
    public string Code { get; set; }
}
