using NewYorkSubway.Common.Models;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Core.Abstractions
{
    public interface IUserService
    {
        Task<AuthResponseModel> TryLoginAsync(AuthModel model, CancellationToken ct);
    }
}
