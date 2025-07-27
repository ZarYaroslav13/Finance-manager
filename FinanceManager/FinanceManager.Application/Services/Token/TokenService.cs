using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Tokens.Commands;
using FinanceManager.Domain.UseCases.Commons.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.UseCases.Commons.Tokens.Commands.RefreshTokenCommand;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceManager.Application.Services.Token;

public class TokenService : BaseService, ITokenService
{
    public TokenService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public static ClaimsIdentity GetIdentityFromJwtToken(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();

        if (!handler.CanReadToken(jwt))
            return new ClaimsIdentity();

        var token = handler.ReadJwtToken(jwt);
        return new(token.Claims, "jwt");
    }

    public async Task<Result<TokenDTO>> LoginAsync(GetTokenRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<GetTokenCommand>(request));

        return _mapper.Map<Result<TokenDTO>>(result);
    }

    public async Task<Result<TokenDTO>> GetRefreshTokenAsync(RefreshTokenRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<RefreshTokenCommand>(request));

        return _mapper.Map<Result<TokenDTO>>(result);
    }
}

