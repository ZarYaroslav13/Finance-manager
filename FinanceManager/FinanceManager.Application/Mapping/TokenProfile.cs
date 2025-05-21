using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<TokenModel, TokenDTO>().ReverseMap();
    }
}
