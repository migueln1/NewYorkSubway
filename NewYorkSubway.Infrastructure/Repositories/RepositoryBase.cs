using Microsoft.EntityFrameworkCore;
using NewYorkSubway.Core.Abstractions;
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

        public Task<List<T>> TryGetAllAsync() => SubwayContext.Set<T>().AsNoTracking().ToListAsync();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
            SubwayContext.Set<T>().Where(expression);
    }
}
