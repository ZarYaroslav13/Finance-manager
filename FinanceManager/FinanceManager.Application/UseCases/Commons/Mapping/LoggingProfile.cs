using AutoMapper;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class LoggingProfile : Profile
{
    public LoggingProfile()
    {
        CreateMap<CreateAccountCommand, AccountModel>();
    }
}
