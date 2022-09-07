using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Commands;
using NewYorkSubway.Common.Models;

namespace NewYorkSubway.Endpoints.Security
{
    public class LoginUserEndpoint : Endpoint<LoginUserModelDto, AuthResponseModel>
    {
        private readonly IMediator _mediator;
        public LoginUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Post("user/login");
            AllowAnonymous();
        }
        public override async Task HandleAsync(LoginUserModelDto req, CancellationToken ct)
        {
            var resp = await _mediator.Send(new LoginUserCommand() { Username = req.Username, Password = req.Password }, ct);
            await SendAsync(resp);
        }
    }
}
