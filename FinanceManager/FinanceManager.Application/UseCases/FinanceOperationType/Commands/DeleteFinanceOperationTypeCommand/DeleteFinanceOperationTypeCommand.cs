using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeCommand : IRequest<IResult>
{

    [GuidRequired]
    public Guid Id { get; set; }
}
