using AutoMapper;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Domain.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class FinanceOperationTypesRequestsProfile : Profile
{
    public FinanceOperationTypesRequestsProfile()
    {
        CreateMap<AddFinanceOperationTypeRequest, AddFinanceOperationTypeCommand>();

        CreateMap<UpdateFinanceOperationTypeRequest, UpdateFinanceOperationTypeCommand>();
    }
}
