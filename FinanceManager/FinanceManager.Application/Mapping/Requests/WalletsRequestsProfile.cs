using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Domain.UseCases.Commons.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.UseCases.Commons.Wallets.Commands.UpdateWalletCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class WalletsRequestsProfile : Profile
{
    public WalletsRequestsProfile()
    {
        CreateMap<WalletDTO, UpdateWalletRequest>().ReverseMap();

        CreateMap<CreateWalletRequest, CreateWalletCommand>();

        CreateMap<UpdateWalletRequest, UpdateWalletCommand>();
    }
}
