using System.ComponentModel.DataAnnotations;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : BaseRequest, IRequest<IResult>
{
    [Required]
    public string Id { get; set; }
}
