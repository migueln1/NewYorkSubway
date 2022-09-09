using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.Extensions.Configuration;
using NewYorkSubway.Common.Models;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Infrastructure.Services
{

    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        private readonly CognitoUserPool _pool;
        private readonly AmazonCognitoIdentityProviderClient _provider;

        public UserService(IConfiguration configuration)
        {
            _config = configuration;
            _provider = new(_config["AWS:AccessKeyId"], _config["AWS:SecretAccessKeyId"], RegionEndpoint.GetBySystemName(_config["AWS:Region"]));
            _pool = new(_config["AWS:PoolId"], _config["AWS:AppClientId"], _provider);
        }
        public async Task<AuthResponseModel> TryLoginAsync(AuthModel model, CancellationToken ct)
        {
            try
            {
                
                CognitoUser user = new(model.Username, _config["AWS:AppClientId"], _pool, _provider);
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