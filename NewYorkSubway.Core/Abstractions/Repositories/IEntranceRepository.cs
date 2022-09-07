using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Core.Abstractions
{
    public interface IEntranceRepository : IRepositoryBase<UserEntrance>
    {
        Task<Guid> TryUseEntranceAsync(UserEntrance entranceUse, CancellationToken ct);
    }
}
