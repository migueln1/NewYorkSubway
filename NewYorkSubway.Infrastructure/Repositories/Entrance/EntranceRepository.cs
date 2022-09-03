
using NewYorkSubway.Core.Models;
using NewYorkSubway.Infrastructure.EntityFramework;

namespace NewYorkSubway.Infrastructure.Repositories
{
    public class EntranceRepository : RepositoryBase<Entrance>, IEntranceRepository
    {
        public EntranceRepository(SubwayDbContext dbContext)
            :base(dbContext)
        {
        }

    }
}
