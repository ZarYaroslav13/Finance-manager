using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.UpdateFinanceOperationCommand;

public class UpdateFinanceOperationCommand : IRequest<Result<FinanceOperationDTO>>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [GuidRequired]
    public Guid TypeId { get; set; }
}
