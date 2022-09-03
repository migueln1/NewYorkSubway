using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Infrastructure.Repositories.Security
{
    public class UserRepository : IUserRepository
    { 

        private readonly AmazonCognitoIdentityProviderClient _provider;
        public UserRepository()
        {
            //TODO use secrets
            _provider = new ("AKIA5UZ6FB7A77Q3BVPS", "DYRK2gDm8Qmx5N4LlDa4DLl1lQSzYNHHt/C/FEVX", RegionEndpoint.GetBySystemName("us-east-1"));
        }
        public async Task<UserSignUpResponseModel> CreateUserAsync(UserSignUpModel model, CancellationToken ct)
        {
            SignUpRequest request = new()
            {
                //TODO use secrets
                ClientId = "1ogugpa6bv9gb3ukk4pi486t83",
                Password = model.Password,
                Username = model.EmailAddress
            };
            request.UserAttributes.Add(new() { Name = "email", Value = model.EmailAddress });
            try
            {
                SignUpResponse response = await _provider.SignUpAsync(request, ct);
                UserSignUpResponseModel signUpResponse = new()
                {
                    UserId = response.UserSub,
                    EmailAddress = model.EmailAddress,
                    Message = $"Confirmation Code sent to {response.CodeDeliveryDetails.Destination} via {response.CodeDeliveryDetails.DeliveryMedium.Value}",
                    IsSuccess = true
                };
                return signUpResponse;
            }
            catch (UsernameExistsException)
            {
                return new()
                {
                    IsSuccess = false,
                    Message = "Email address already exists"
                };
            }
        }

        public Task<AuthResponseModel> TryLoginAsync(UserLoginModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
