using System.Linq.Expressions;

namespace TestCase.Domain.Repositories.Base;

public interface IQueryBuilder<T>
{
    Task<IReadOnlyList<T>> ToListAsync();
    Task<T?> FirstOrDefaultAsync();
    IQueryBuilder<T> Where(Expression<Func<T, bool>> predicate);
    Task<bool> Any(Expression<Func<T, bool>> predicate);
}
