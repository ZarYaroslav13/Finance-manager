using System.Linq.Expressions;
using FinanceManager.Infrastructure.Models.Base;

namespace FinanceManager.Infrastructure.Repository;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
                Expression<Func<T, bool>> filter = null,
                int skip = 0,
                int take = 0,
                params string[] includeProperties);

    Task<T> GetByIdAsync(Guid id);

    Task<T> FindBy(Expression<Func<T, bool>> filter, params string[] includeProperties);

    T Insert(T entity);

    T Update(T entity);

    void Delete(Guid id);
}