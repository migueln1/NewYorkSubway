using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Commands;

namespace NewYorkSubway.Endpoints
{
    public class UserEntranceEndpoint : Endpoint<UseEntranceDto, EntranceUsedResponseDto>
    {
        private readonly IMediator _mediator;

        public UserEntranceEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("entrances/{EntranceId}/user/{Username}");
        }

        public override async Task HandleAsync(UseEntranceDto request, CancellationToken ct)
        {
            var resp = await _mediator.Send(new UserEntranceCommand() { EntranceId = request.EntranceId, Username = request.Username }, ct);
            await SendAsync(resp, cancellation: ct);
        }
    }
}
