using AutoMapper;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Mapper.Profiles
{
    public class ResultConverter<TSource, TDestination> : ITypeConverter<Result<TSource>, Result<TDestination>>
    {
        private readonly IMapper _mapper;

        public ResultConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Result<TDestination> Convert(Result<TSource> source, Result<TDestination> destination, ResolutionContext context)
        {
            return new Result<TDestination>()
            {
                Succeeded = source.Succeeded,
                Messages = source.Messages,
                Data = _mapper.Map<TDestination>(source.Data)
            };
        }
    }
}
