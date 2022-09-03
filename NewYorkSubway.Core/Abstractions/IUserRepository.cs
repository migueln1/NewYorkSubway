using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Core.Abstractions
{
    public interface IUserRepository
    {
        Task<AuthResponseModel> TryLoginAsync(UserLoginModel model, CancellationToken ct);
        Task<UserSignUpResponseModel> CreateUserAsync(UserSignUpModel model, CancellationToken ct);
    }
}
