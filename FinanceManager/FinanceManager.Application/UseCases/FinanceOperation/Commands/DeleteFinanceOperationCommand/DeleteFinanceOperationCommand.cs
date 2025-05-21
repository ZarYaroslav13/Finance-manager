using System.ComponentModel.DataAnnotations;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationCommand : IRequest<IResult>
{
    [Required]
    public string Id { get; set; }
}
