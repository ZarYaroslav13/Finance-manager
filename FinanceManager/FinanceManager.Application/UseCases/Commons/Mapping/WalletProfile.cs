using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<CreateWalletCommand, WalletModel>();

        CreateMap<UpdateWalletCommand, WalletModel>();

        CreateMap<WalletDTO, UpdateWalletCommand>().ReverseMap();
    }
}
