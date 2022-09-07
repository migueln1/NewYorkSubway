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
            return await GetEntrances(ct);
        }

        public async Task<double> GetDistance(int entranceAId, int entranceBId, CancellationToken ct)
        {
            GeoModelRoot entrances = await GetEntrances(ct);
            Feature[]? features = entrances?.features?.Where(f => f.properties?.objectid == entranceAId.ToString()
                || f.properties?.objectid == entranceBId.ToString()).Distinct().ToArray();

            double result = CalculateDistance(features);
            return result;
        }

        private static async Task<GeoModelRoot> GetEntrances(CancellationToken ct)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "NewYorkSubway.Infrastructure.Data.SubwayEntrances.geojson";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream is null) throw new Exception("the file cannot be loaded");
            return await JsonSerializer.DeserializeAsync<GeoModelRoot>(stream, cancellationToken: ct);
        }

        private static double CalculateDistance(Feature[] points)
        {
            double oneDegree = Math.PI / 180.0;
            var d1 = points[0]?.geometry?.coordinates?[1] * oneDegree;
            var num1 = points[0]?.geometry?.coordinates?[0] * oneDegree;
            var d2 = points[1]?.geometry?.coordinates?[1] * oneDegree;
            var num2 = points[1]?.geometry?.coordinates?[0] * oneDegree - num1;
            var d3 = d1.HasValue && d2.HasValue && num2.HasValue ?
                    Math.Pow(Math.Sin((d2.Value - d1.Value) / 2.0), 2.0) + Math.Cos(d1.Value) * Math.Cos(d2.Value) * Math.Pow(Math.Sin(num2.Value / 2.0), 2.0) :
                    -1;

            return d3 > -1 ? 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) : 0;
        }
    }
}