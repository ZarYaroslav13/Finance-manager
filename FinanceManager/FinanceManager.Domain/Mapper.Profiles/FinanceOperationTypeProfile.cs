using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Mapper.Profiles;

public class FinanceOperationTypeProfile : Profile
{
    public FinanceOperationTypeProfile()
    {
        CreateMap<FinanceOperationType, FinanceOperationTypeModel>()
           .ForMember(dest => dest.WalletName, opt => opt.MapFrom(src => (src.Wallet != null) ? src.Wallet.Name : string.Empty));

        CreateMap<FinanceOperationTypeModel, FinanceOperationType>();
    }
}
