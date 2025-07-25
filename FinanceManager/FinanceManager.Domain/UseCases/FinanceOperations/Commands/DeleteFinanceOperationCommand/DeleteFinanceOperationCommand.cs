using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
