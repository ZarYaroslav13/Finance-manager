using AutoMapper;
using FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;
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
        CreateMap<CreateWalletCommand, WalletModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AccountId));
    }
}
