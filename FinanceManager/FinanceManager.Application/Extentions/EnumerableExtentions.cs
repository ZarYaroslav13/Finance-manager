using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Extentions;

public static class EnumerableExtentions
{
    public static PaginatedResult<T> ToPaginatedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize) where T : class
    {
        if (source == null) throw new Exception();

        pageNumber = pageNumber == 0 ? 1 : pageNumber;
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;

        pageSize = pageSize == 0 ? 10 : pageSize;

        int count = source.Count();

        List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
    }
}
