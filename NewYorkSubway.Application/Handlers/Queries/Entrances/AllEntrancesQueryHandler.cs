using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Core.Abstractions;

namespace NewYorkSubway.Application.Handlers.Queries.Entrances
{
    public class GetAllEntrancesQuery : IRequest<GetAllEntrancesResponseDto> { };
    public class GetAllEntrancesQueryHandler : IRequestHandler<GetAllEntrancesQuery, GetAllEntrancesResponseDto>
    {
        private readonly IEntranceService _entranceService;
        public GetAllEntrancesQueryHandler(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }

        public async Task<GetAllEntrancesResponseDto> Handle(GetAllEntrancesQuery request, CancellationToken cancellationToken)
        {
            var rawData = await _entranceService.TryGetSubwayDataAsync(cancellationToken);
            //TODO Manage possible null values
            var data = rawData.features?
                .Select(f => new EntranceDto() { EntranceId = int.Parse(f.properties.objectid), Name = f.properties.name, Longitude = f.geometry.coordinates[0], Latitude = f.geometry.coordinates[1] });
            GetAllEntrancesResponseDto response = new() { Entrances = data.ToList() };
            return response;
        }
    }
}
