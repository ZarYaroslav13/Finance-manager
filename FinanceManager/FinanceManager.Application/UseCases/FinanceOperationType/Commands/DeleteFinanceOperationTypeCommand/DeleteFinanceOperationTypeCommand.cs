using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeCommand : IRequest<IResult>
{
    public string Id { get; set; }
}
