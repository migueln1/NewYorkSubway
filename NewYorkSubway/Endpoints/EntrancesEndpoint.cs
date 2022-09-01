using NewYorkSubway.Application.DTOs;

namespace NewYorkSubway.Endpoints
{
    public class EntrancesEndpoint : EndpointWithoutRequest<GetEntranceResponseDto>
    {
        public override void Configure()
        {
            Get("/api/entrances");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            GetEntranceResponseDto response = new()
            {
                Entrances = new()
                {
                    new() { Name = "Bronx" }
                }
            };
            await SendAsync(response);
        }
    }
}