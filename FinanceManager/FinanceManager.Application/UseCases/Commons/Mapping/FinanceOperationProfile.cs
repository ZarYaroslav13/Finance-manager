using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class FinanceOperationProfile : Profile
{
    public FinanceOperationProfile()
    {
        CreateMap<FinanceOperationDTO, UpdateFinanceOperationCommand>();

        CreateMap<AddFinanceOperationCommand, FinanceOperationModel>().ConvertUsing((updateCommand, financeOperationModel, context) =>
        {
            var type = new FinanceOperationTypeModel() { Id = updateCommand.TypeId, EntryType = EntryType.Income };

            return new IncomeModel(type)
            {
                Amount = updateCommand.Amount,
                Date = updateCommand.Date,
            };
        }); ;

        CreateMap<UpdateFinanceOperationCommand, FinanceOperationModel>()
            .ConvertUsing((updateCommand, financeOperationModel, context) =>
            {
                var type = new FinanceOperationTypeModel() { Id = updateCommand.TypeId, EntryType = EntryType.Income };

                return new IncomeModel(type)
                {
                    Id = updateCommand.Id,
                    Amount = updateCommand.Amount,
                    Date = updateCommand.Date,

                };
            });
    }
}
