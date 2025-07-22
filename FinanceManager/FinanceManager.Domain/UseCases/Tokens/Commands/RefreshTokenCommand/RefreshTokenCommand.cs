using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Tokens.Commands.RefreshTokenCommand;

public class RefreshTokenCommand : IRequest<Result<TokenModel>>
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
