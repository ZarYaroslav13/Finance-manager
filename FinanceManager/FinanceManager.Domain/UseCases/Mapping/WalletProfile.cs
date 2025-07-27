using AutoMapper;
using FinanceManager.Domain.UseCases.Commons.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.UseCases.Commons.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.Mapping;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<CreateWalletCommand, Wallet>();

        CreateMap<UpdateWalletCommand, Wallet>();
    }
}
