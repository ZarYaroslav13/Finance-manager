using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class FinanceOperationTypeProfile : Profile
{
    public FinanceOperationTypeProfile()
    {
        CreateMap<FinanceOperationTypeModel, FinanceOperationTypeDTO>().ReverseMap();
    }
}
