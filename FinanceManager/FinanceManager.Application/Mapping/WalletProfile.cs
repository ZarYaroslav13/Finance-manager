using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.UseCases.Commons.Wallets.Commands.UpdateWalletCommand;

namespace FinanceManager.Application.Mapping;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<WalletModel, WalletDTO>().ReverseMap();

        CreateMap<WalletDTO, UpdateWalletCommand>();
    }
}
