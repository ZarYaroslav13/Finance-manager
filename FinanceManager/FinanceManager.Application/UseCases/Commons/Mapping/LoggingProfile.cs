using AutoMapper;
using FinanceManager.Application.UseCases.Login.Commands.CreateAccountCommand;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class LoggingProfile : Profile
{
    public LoggingProfile()
    {
        CreateMap<CreateAccountCommand, AccountModel>();
    }
}
