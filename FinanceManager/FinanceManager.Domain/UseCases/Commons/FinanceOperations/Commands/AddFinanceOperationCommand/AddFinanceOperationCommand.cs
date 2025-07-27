using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperations.Commands.AddFinanceOperationCommand;

public class AddFinanceOperationCommand : IRequest<IResult<FinanceOperationModel>>
{
    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [GuidRequired]
    public Guid TypeId { get; set; }

    [Required]
    public bool IsCallerOwner { get; set; }
}
