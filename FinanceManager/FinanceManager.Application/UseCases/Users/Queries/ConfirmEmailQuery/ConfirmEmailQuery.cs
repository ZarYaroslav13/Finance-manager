using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Users.Queries.ConfirmEmailQuery;

public class ConfirmEmailQuery : IRequest<IResult>
{
    [GuidRequired]
    public Guid UserId { get; set; }

    [Required]
    public string Code { get; set; }
}
