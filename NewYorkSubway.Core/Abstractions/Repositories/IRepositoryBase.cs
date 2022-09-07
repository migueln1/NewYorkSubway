using System.Linq.Expressions;

namespace NewYorkSubway.Core.Abstractions;
public interface IRepositoryBase<T>
{
    Task<List<T>> TryGetAllAsync();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
}

