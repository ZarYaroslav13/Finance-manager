using AutoMapper;
using FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.Mapping;

public class FinanceOperationTypesProfile : Profile
{
    public FinanceOperationTypesProfile()
    {
        CreateMap<AddFinanceOperationTypeCommand, FinanceOperationType>();

        CreateMap<UpdateFinanceOperationTypeCommand, FinanceOperationType>();
    }
}
