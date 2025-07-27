using AutoMapper;
using FinanceManager.Application.Models.Requests.Tokens.Commands;
using FinanceManager.Domain.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.UseCases.Tokens.Commands.RefreshTokenCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class TokenRequestsProfile : Profile
{
    public TokenRequestsProfile()
    {
        CreateMap<GetTokenRequest, GetTokenCommand>();

        CreateMap<RefreshTokenRequest, RefreshTokenCommand>();
    }
}
