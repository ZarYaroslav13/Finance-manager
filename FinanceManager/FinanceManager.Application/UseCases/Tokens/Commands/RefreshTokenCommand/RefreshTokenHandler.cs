using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Token;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Tokens.Commands.RefreshTokenCommand;

public class RefreshTokenHandler : BaseRequestHandler, IRequestHandler<RefreshTokenCommand, Result<TokenDTO>>
{
    private readonly ITokenService _tokenManager;

    public RefreshTokenHandler(ITokenService tokenManager,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
    }

    public async Task<Result<TokenDTO>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            var result = await _tokenManager.GetRefreshTokenAsync(request.Token, request.RefreshToken);

            return new Result<TokenDTO>
            {
                Messages = result.Messages,
                Data = _mapper.Map<TokenDTO>(result.Data),
                Succeeded = result.Succeeded
            };
        });
    }
}
