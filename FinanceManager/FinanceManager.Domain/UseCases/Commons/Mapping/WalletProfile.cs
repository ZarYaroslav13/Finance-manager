using AutoMapper;
using FinanceManager.Domain.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.Commons.Mapping;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<CreateWalletCommand, Wallet>();

        CreateMap<UpdateWalletCommand, Wallet>();
    }
}
