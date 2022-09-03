using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Commands;

namespace NewYorkSubway.Endpoints.Security
{
    public class SignUpUserEndpoint : Endpoint<SignUpUserModelDto, bool>
    {
        private readonly IMediator _mediator;
        public SignUpUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Post("user");
            AllowAnonymous();
        }
        public override async Task HandleAsync(SignUpUserModelDto req, CancellationToken ct)
        {
            await _mediator.Send(new SignUpUserCommand(), ct);
        }
    }
}
