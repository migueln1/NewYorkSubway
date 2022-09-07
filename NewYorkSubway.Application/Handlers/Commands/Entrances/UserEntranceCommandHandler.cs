using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

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
        private readonly IEntranceRepository _entranceRepository;
        public UserEntranceCommandHandler(IEntranceService entranceService, IEntranceRepository entranceRepository)
        {
            _entranceService = entranceService;
            _entranceRepository = entranceRepository;
        }
        //TODO use repository
        public async Task<EntranceUsedResponseDto> Handle(UserEntranceCommand request, CancellationToken cancellationToken)
        {
            Task<GeoModelRoot> getEntrancesInfoTask = _entranceService.TryGetSubwayDataAsync(cancellationToken);
            Task<Guid> addEntranceUseTask = _entranceRepository
                .TryUseEntranceAsync(new UserEntrance() { EntranceId = request.EntranceId, UserId = request.Username }, cancellationToken);

            var tasks = Task.WhenAll(getEntrancesInfoTask, addEntranceUseTask);

            try
            {
               await tasks;
            }
            catch
            {
                string errorMessage = "";
                tasks.Exception?.InnerExceptions
                    .ToList()
                    .ForEach(e => errorMessage += $"/// {e.Message}");
                return new EntranceUsedResponseDto(false, errorMessage);
            }
            Guid entityId = await addEntranceUseTask;
            
            string? entranceName = (await getEntrancesInfoTask).features?.FirstOrDefault(f => f.properties?.objectid == request.EntranceId.ToString())?.properties?.name;

            return new EntranceUsedResponseDto(true, null) { Id = entityId, EntranceId = request.EntranceId, Username = request.Username, EntranceName = entranceName };
            
        }
    }
}

