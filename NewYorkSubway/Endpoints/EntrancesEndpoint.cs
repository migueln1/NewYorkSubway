using NewYorkSubway.Application.DTOs;

namespace NewYorkSubway.Endpoints
{
    public class EntrancesEndpoint : EndpointWithoutRequest<GetAllEntrancesResponseDto>
    {
        public override void Configure()
        {
            Get("entrances");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            GetAllEntrancesResponseDto response = new()
            {
                Entrances = new()
                {
                    new() { Name = "Bronx" }
                }
            };
            await SendAsync(response, cancellation: ct);
        }
    }
}