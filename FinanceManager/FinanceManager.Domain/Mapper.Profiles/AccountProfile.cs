using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Mapper.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountModel>().ReverseMap();
    }
}
