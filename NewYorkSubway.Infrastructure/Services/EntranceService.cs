using NewYorkSubway.Core.Abstractions;
using NewYorkSubway.Core.Models;
using System.Reflection;
using System.Text.Json;

namespace NewYorkSubway.Infrastructure.Services
{
    public class EntranceService : IEntranceService
    {
        public async Task<GeoModelRoot> TryGetSubwayDataAsync(CancellationToken ct)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "NewYorkSubway.Infrastructure.Data.SubwayEntrances.geojson";
            
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream is null) throw new Exception("the file cannot be loaded");
            return await JsonSerializer.DeserializeAsync<GeoModelRoot>(stream,cancellationToken:ct);
        }
    }
}
