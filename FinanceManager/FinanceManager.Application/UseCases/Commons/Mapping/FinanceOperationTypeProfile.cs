using AutoMapper;
using FinanceManager.Application.UseCases.FinanceOperationType.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationType.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class FinanceOperationTypeProfile : Profile
{
    public FinanceOperationTypeProfile()
    {
        CreateMap<AddFinanceOperationTypeCommand, FinanceOperationTypeModel>();

        CreateMap<UpdateFinanceOperationTypeCommand, FinanceOperationTypeModel>();
    }
}
