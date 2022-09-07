using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Queries;

namespace NewYorkSubway.Endpoints.Entrances
{
    public class GetMostUsedEntranceByUserEndpoint : Endpoint<GetMostUsedRequestDto, GetMostUsedEntrancesResponseDto>
    {
        private readonly IMediator _mediator;

        public GetMostUsedEntranceByUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("entrances/user/{Username}");
        }
        public override async Task HandleAsync(GetMostUsedRequestDto req, CancellationToken ct)
        {
            var resp = await _mediator.Send(new GetUsedEntrancesQuery() { Username = req.Username }, ct);
            await SendAsync(resp);

        }
    }
}
