using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Queries.Entrances;

namespace NewYorkSubway.Endpoints
{
    public class EntrancesEndpoint : EndpointWithoutRequest<GetAllEntrancesResponseDto>
    {
        private readonly IMediator _mediator;

        public EntrancesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("entrances");
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var resp = await _mediator.Send(new GetAllEntrancesQuery(), ct);
            await SendAsync(resp);
            
        }
    }
}