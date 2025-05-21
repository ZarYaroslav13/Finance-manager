using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.AddFinanceOperationCommand;

public class AddFinanceOperationCommand : IRequest<Result<FinanceOperationDTO>>
{
    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string TypeId { get; set; }
}
