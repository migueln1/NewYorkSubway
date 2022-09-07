using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Handlers.Queries.Entrances;

namespace NewYorkSubway.Endpoints
{
    public class GetEntrancesEndpoint : EndpointWithoutRequest<GetAllEntrancesResponseDto>
    {
        private readonly IMediator _mediator;

        public GetEntrancesEndpoint(IMediator mediator)
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