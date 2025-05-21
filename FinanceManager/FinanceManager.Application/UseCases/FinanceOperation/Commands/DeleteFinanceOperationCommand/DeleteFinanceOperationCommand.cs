using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationCommand : BaseRequest, IRequest<BaseResponse<bool>>
{
    [Required]
    public int Id { get; set; }
}
