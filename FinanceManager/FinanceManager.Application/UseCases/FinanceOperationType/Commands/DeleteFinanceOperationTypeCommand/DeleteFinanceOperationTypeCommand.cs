using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeCommand : IRequest<IResult>
{

    [GuidRequired]
    public Guid Id { get; set; }
}
