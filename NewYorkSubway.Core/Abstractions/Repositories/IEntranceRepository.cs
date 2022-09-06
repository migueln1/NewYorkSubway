using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Core.Abstractions
{
    public interface IEntranceRepository : IRepositoryBase<UserEntrance>
    {
        //Task<UserEntranceResponse> TryUseEntranceAsync(int entranceId, string username, CancellationToken ct);
    }
}
