using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Queries;

namespace NewYorkSubway.Endpoints.Entrances
{
    public class EntrancesDistanceEndpoint : Endpoint<EntranceDistanceQueryDto, EntranceDistanceResponseDto> 
    {
        private readonly IMediator _mediator;

        public EntrancesDistanceEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("entrances/distance/{EntranceAId}/{EntranceBId}");
        }

        public override async Task HandleAsync(EntranceDistanceQueryDto request, CancellationToken ct)
        {
            var resp = await _mediator.Send(new EntranceDistanceQuery() { EntranceAId = request.EntranceAId, EntranceBId = request.EntranceBId }, ct);
            await SendAsync(resp, cancellation: ct);
        }
    }
}
