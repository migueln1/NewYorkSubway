using MediatR;

namespace NewYorkSubway.Application.Handlers.Commands.Security
{
    public class CredentialsAreValidCommand : IRequest<bool>
    {
        public string? Username { get; init; }
        public string? Password { get; init; }
    }
    public class CredentialsAreValidCommandHandler : IRequestHandler<CredentialsAreValidCommand, bool>
    {
        public CredentialsAreValidCommandHandler()
        {

        }

        Task<bool> IRequestHandler<CredentialsAreValidCommand, bool>.Handle(CredentialsAreValidCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
