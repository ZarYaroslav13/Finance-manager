using AutoMapper;
using FinanceManager.Domain.UseCases.Commons.FinanceOperations.Commands.AddFinanceOperationCommand;
using FinanceManager.Domain.UseCases.Commons.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.Mapping;

public class FinanceOperationsProfile : Profile
{
    public FinanceOperationsProfile()
    {
        CreateMap<AddFinanceOperationCommand, FinanceOperation>();

        CreateMap<UpdateFinanceOperationCommand, FinanceOperation>();
    }
}
