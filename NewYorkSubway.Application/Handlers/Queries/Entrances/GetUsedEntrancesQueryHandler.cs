using MediatR;
using NewYorkSubway.Application.DTOs;
using NewYorkSubway.Application.Helpers;
using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Application.Handlers.Queries
{
    public class GetUsedEntrancesQuery : IRequest<GetMostUsedEntrancesResponseDto>
    {
        public string? Username { get; init; }
    }
    public class GetUsedEntrancesQueryHandler : IRequestHandler<GetUsedEntrancesQuery, GetMostUsedEntrancesResponseDto>
    {
        private readonly IEntranceService _entranceService;
        private readonly IEntranceRepository _entranceRepository;
        public GetUsedEntrancesQueryHandler(IEntranceRepository entranceRepository, IEntranceService entranceService)
        {
            _entranceRepository = entranceRepository;
            _entranceService = entranceService;
        }

        public async Task<GetMostUsedEntrancesResponseDto> Handle(GetUsedEntrancesQuery request, CancellationToken ct)
        {
            Task<GeoModelRoot> getEntrancesInfoTask = _entranceService.TryGetSubwayDataAsync(ct);
            Task<List<UserEntrance>> entrancesTask = _entranceRepository.TryGetAllAsync();
            var allTasks = Task.WhenAll(getEntrancesInfoTask, entrancesTask);
            try
            {
                await allTasks;
            }
            catch
            {
                string errorMessage = "";
                allTasks.Exception?.InnerExceptions
                    .ToList()
                    .ForEach(e => errorMessage += $"/// {e.Message}");
                return new GetMostUsedEntrancesResponseDto(false, errorMessage);
            }
            var mostUsedEntrances = (await entrancesTask).Where(ue => ue.UserId == request.Username)
                .GroupBy(e => e.EntranceId)
                .Select(async e => new UsedEntranceDto() { 
                    EntranceId = e.Key, 
                    EntranceName = (await getEntrancesInfoTask).GetNameById(e.Key), 
                    Count = e.Count() })
                .Select(t => t.Result)
                .ToList();

            return new GetMostUsedEntrancesResponseDto(true, null) { Entrances = mostUsedEntrances };

           
        }

    }
}
