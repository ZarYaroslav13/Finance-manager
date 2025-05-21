using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperations.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
