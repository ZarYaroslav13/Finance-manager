using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<WalletModel, WalletDTO>().ReverseMap();
    }
}
