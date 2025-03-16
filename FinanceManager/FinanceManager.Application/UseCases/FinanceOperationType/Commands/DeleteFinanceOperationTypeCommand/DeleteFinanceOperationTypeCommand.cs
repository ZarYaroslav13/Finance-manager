using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeCommand : BaseRequest, IRequest<BaseResponse<bool>>
{
    public int Id { get; set; }
}
