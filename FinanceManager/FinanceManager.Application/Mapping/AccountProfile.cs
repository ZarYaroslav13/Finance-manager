using AutoMapper;
using FinanceManager.Application.Models;

namespace FinanceManager.Application.Mapping;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountModel, AccountDTO>().ReverseMap();
    }
}
