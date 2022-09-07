using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;
using NewYorkSubway.Infrastructure.EntityFramework;

namespace NewYorkSubway.Infrastructure.Repositories
{
    public class EntranceRepository : RepositoryBase<UserEntrance>, IEntranceRepository
    {
        private readonly SubwayDbContext _context;

        public EntranceRepository(SubwayDbContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Guid> TryUseEntranceAsync(UserEntrance entranceUse, CancellationToken ct)
        {
            try
            {
                await _context.AddAsync(entranceUse, ct);
                await _context.SaveChangesAsync(ct);
                return entranceUse.Id;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}