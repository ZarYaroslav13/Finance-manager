using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeCommand : IRequest<IResult>
{

    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
