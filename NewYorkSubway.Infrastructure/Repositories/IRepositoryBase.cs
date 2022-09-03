using System.Linq.Expressions;

namespace NewYorkSubway.Infrastructure.Repositories;
public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
}

