using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Application.Helpers
{
    public static class GetEntranceName
    {
        public static string? GetNameById(this GeoModelRoot info, int entranceId)
        {
            return info.features?
                .FirstOrDefault(e => e.properties?.objectid == entranceId.ToString())?.properties?.name;
        }
    }
}
