using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.UpdateFinanceOperationCommand;

public class UpdateFinanceOperationCommand : BaseRequest, IRequest<BaseResponse<FinanceOperationDTO>>
{
    [Required]
    public int Id { get; set; }

    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int TypeId { get; set; }
}
