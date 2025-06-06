using AutoMapper;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Mapper.Profiles;

public class ResultProflle : Profile
{
    public ResultProflle()
    {
        CreateMap<Result, Result>();

        CreateMap(typeof(Result<>), typeof(Result<>)).ConvertUsing(typeof(ResultConverter<,>));
    }
}
