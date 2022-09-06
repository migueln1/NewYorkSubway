using MediatR;
using NewYorkSubway.Common.Models;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Application.Handlers.Commands
{
    public class LoginUserCommand : IRequest<AuthResponseModel>
    {
        public string? Username { get; init; }
        public string? Password { get; init; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseModel>
    {
        private readonly IUserService _userRepository;
        public LoginUserCommandHandler(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthResponseModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            AuthResponseModel response =  await _userRepository.TryLoginAsync(new AuthModel() { Username = request.Username, Password = request.Password }, cancellationToken);
            return response;
        }
    }
}
