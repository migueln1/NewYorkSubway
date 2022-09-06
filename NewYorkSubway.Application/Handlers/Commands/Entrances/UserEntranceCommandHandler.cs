using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Core.Abstractions;

namespace NewYorkSubway.Application.Handlers.Commands
{
    public class UserEntranceCommand : IRequest<EntranceUsedResponseDto>
    {
        public int EntranceId { get; init; }
        public string? Username { get; set; }
    }

    public class UserEntranceCommandHandler : IRequestHandler<UserEntranceCommand, EntranceUsedResponseDto>
    {
        private readonly IEntranceService _entranceService;
        public UserEntranceCommandHandler(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }
        //TODO use repository
        public async Task<EntranceUsedResponseDto> Handle(UserEntranceCommand request, CancellationToken cancellationToken)
        {
            var entrance = (await _entranceService.TryGetSubwayDataAsync(cancellationToken)).features?
                .FirstOrDefault(e => e.properties?.objectid == request.EntranceId.ToString());

            if(entrance is null) return new EntranceUsedResponseDto(false, "No entrance found with this identifier");

            return new(true, null) { EntranceId = 1743, Count = 2 };
        }
    }
}

