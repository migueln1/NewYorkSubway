using Microsoft.EntityFrameworkCore;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Infrastructure.EntityFramework
{
    public class SubwayDbContext : DbContext 
    {
        public SubwayDbContext() {}
        public SubwayDbContext(DbContextOptions<SubwayDbContext> options) : base(options) {}
        public virtual DbSet<UserEntrance> UserEntrances { get; set; }

    }
}
