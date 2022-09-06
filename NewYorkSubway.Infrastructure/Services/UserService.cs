using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using NewYorkSubway.Common.Models;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly CognitoUserPool _pool;
        private readonly AmazonCognitoIdentityProviderClient _provider;
        public UserService()
        {
            //TODO use secrets

            _provider = new("AKIA5UZ6FB7A77Q3BVPS", "DYRK2gDm8Qmx5N4LlDa4DLl1lQSzYNHHt/C/FEVX", RegionEndpoint.GetBySystemName("us-east-1"));
            _pool = new("us-east-1_8pXaKoy2L", "1bnv9lucgnkct5rbikr0rb3lu5", _provider);
        }
        public async Task<AuthResponseModel> TryLoginAsync(AuthModel model, CancellationToken ct)
        {
            try
            {
                //TODO Use secrets
                CognitoUser user = new(model.Username, "1bnv9lucgnkct5rbikr0rb3lu5", _pool, _provider);
                InitiateSrpAuthRequest authRequest = new()
                {
                    Password = model.Password
                };
                AuthFlowResponse authResponse = await user.StartWithSrpAuthAsync(authRequest);
                var result = authResponse.AuthenticationResult;
                AuthResponseModel response = new()
                {
                    UserId = user.UserID,
                    Tokens = new()
                    {
                        AccessToken = result.AccessToken,
                        ExpiresIn = result.ExpiresIn,
                        RefreshToken = result.RefreshToken
                    },
                    IsSuccess = true
                };
                return response;
            }
            catch (UserNotConfirmedException)
            {
                return new AuthResponseModel()
                {
                    IsSuccess = false,
                    Message = "User has signed up but has not confirmed his EmailAddress"
                };
            }
            catch (UserNotFoundException)
            {
                return new AuthResponseModel()
                {
                    IsSuccess = false,
                    Message = "The provided username doesn't exist in the UserPool"
                };
            }
            catch (NotAuthorizedException)
            {
                return new AuthResponseModel()
                {
                    IsSuccess = false,
                    Message = "Not authorized action"
                };
            }

        }

    }
}
