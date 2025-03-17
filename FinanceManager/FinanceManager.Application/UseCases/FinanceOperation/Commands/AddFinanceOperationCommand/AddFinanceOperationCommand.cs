using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.AddFinanceOperationCommand;

public class AddFinanceOperationCommand : BaseRequest, IRequest<BaseResponse<FinanceOperationDTO>>
{
    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int TypeId { get; set; }
}
