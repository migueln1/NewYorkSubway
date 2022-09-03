using MediatR;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Application.Handlers.Commands
{
    public class SignUpUserCommand : IRequest<bool>
    {
        public string EmailAddress { get; init; }
        public string Password { get; init; }
    }
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public SignUpUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(SignUpUserCommand request, CancellationToken ct)
        {
            //TODO use cancellation token
            UserSignUpResponseModel response =  await _userRepository.CreateUserAsync(new() { EmailAddress = request.EmailAddress, Password = request.Password }, ct);
            return response.IsSuccess;
        }
    }
}
