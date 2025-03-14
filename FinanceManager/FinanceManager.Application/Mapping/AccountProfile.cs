using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountModel, AccountDTO>().ReverseMap();
    }
}
