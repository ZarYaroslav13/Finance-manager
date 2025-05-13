using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Login.Commands.CreateRefreshTokenCommand;

public class CreateRefreshTokenHandler : BaseRequestHandler, IRequestHandler<CreateRefreshTokenCommand, BaseResponse<TokenDTO>>
{
    public CreateRefreshTokenHandler(IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
    }

    public async Task<BaseResponse<TokenDTO>> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
