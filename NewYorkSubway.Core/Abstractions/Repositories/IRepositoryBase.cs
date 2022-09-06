using System.Linq.Expressions;

namespace NewYorkSubway.Core.Abstractions;
public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
}

