
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;
using NewYorkSubway.Infrastructure.EntityFramework;
using System.Linq.Expressions;

namespace NewYorkSubway.Infrastructure.Repositories
{
    public class EntranceRepository : RepositoryBase<UserEntrance>, IEntranceRepository
    {
        private readonly SubwayDbContext _context;
        public EntranceRepository(SubwayDbContext dbContext)
            :base(dbContext)
        {
            _context = dbContext;
        }

        //TODO Finish
        //public Task<UserEntranceResponse> TryUseEntranceAsync(int entranceId, string username, CancellationToken ct)
        //{

        //}
    }
}
