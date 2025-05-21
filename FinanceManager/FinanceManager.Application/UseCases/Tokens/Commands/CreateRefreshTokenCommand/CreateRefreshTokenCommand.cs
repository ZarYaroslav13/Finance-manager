using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Tokens.Commands.CreateRefreshTokenCommand;

public class CreateRefreshTokenCommand : IRequest<Result<TokenDTO>>
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
