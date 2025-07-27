using AutoMapper;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Domain.UseCases.FinanceOperations.Commands.AddFinanceOperationCommand;
using FinanceManager.Domain.UseCases.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfTypeQuery;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletInPeriodQuery;
using FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;

namespace FinanceManager.Application.Mapping.Requests;

public class FinanceOperationsRequestsProfile : Profile
{
    public FinanceOperationsRequestsProfile()
    {
        CreateMap<GetAllOperationsOfTypeRequest, GetAllOperationsOfTypeQuery>();
        CreateMap<GetAllOperationsOfWalletInPeriodRequest, GetAllOperationsOfWalletInPeriodQuery>();
        CreateMap<GetAllOperationsOfWalletRequest, GetAllOperationsOfWalletQuery>();

        CreateMap<AddFinanceOperationRequest, AddFinanceOperationCommand>();
        CreateMap<UpdateFinanceOperationRequest, UpdateFinanceOperationCommand>();
    }
}
