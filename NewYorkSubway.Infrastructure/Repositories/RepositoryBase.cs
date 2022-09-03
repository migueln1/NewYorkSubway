using Microsoft.EntityFrameworkCore;
using NewYorkSubway.Infrastructure.EntityFramework;
using System.Linq.Expressions;

namespace NewYorkSubway.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SubwayDbContext SubwayContext;

        public RepositoryBase(SubwayDbContext context)
        {
            SubwayContext = context;
        }

        public IQueryable<T> GetAll() => SubwayContext.Set<T>().AsNoTracking();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
            SubwayContext.Set<T>().Where(expression);
    }
}
