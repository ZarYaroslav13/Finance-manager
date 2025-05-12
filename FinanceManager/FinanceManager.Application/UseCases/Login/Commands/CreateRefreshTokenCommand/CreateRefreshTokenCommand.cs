using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Login.Commands.CreateRefreshTokenCommand;

public class CreateRefreshTokenCommand : IRequest<BaseResponse<string>>
{
    public string JwtToken { get; set; }
    public string RefreshToken { get; set; }
}
