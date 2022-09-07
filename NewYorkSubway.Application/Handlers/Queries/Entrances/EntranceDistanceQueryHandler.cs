using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Core.Abstractions;

namespace NewYorkSubway.Application.Handlers.Queries
{
    public class EntranceDistanceQuery : IRequest<EntranceDistanceResponseDto>
    {
        public int EntranceAId { get; init; }
        public int EntranceBId { get; init; }
    }
    public class EntranceDistanceQueryHandler : IRequestHandler<EntranceDistanceQuery, EntranceDistanceResponseDto>
    {
        private readonly IEntranceService _entranceService;
        public EntranceDistanceQueryHandler(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }

        public async Task<EntranceDistanceResponseDto> Handle(EntranceDistanceQuery request, CancellationToken cancellationToken)
        {
            var result = await _entranceService.GetDistance(request.EntranceAId, request.EntranceBId, cancellationToken);
            return new EntranceDistanceResponseDto() { Distance = result };
        }
    }
}
