using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationCommand : BaseRequest, IRequest<BaseResponse<bool>>
{
    [Required]
    public int Id { get; set; }
}
