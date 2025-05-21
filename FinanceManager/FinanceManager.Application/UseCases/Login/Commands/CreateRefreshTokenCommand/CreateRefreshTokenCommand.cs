using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Login.Commands.CreateRefreshTokenCommand;

public class CreateRefreshTokenCommand : IRequest<BaseResponse<TokenDTO>>
{
    public string JwtToken { get; set; }
    public string RefreshToken { get; set; }
}
