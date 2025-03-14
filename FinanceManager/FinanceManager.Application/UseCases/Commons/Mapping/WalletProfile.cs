using AutoMapper;
using FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallet.Commands.UpdateWalletCommand;
using FinanceManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<CreateWalletCommand, WalletModel>();

        CreateMap<UpdateWalletCommand, WalletModel>();
    }
}
