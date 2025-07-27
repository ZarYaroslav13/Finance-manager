using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Tokens.Commands.RefreshTokenCommand;

public class RefreshTokenCommand : IRequest<Result<TokenModel>>
{
    [Required]
    public string Token { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}
