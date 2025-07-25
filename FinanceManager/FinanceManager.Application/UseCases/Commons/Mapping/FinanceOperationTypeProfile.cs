using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class FinanceOperationTypeProfile : Profile
{
    public FinanceOperationTypeProfile()
    {
        CreateMap<FinanceOperationTypeDTO, UpdateFinanceOperationTypeCommand>();

        CreateMap<AddFinanceOperationTypeCommand, FinanceOperationTypeModel>();

        CreateMap<UpdateFinanceOperationTypeCommand, FinanceOperationTypeModel>();
    }
}
