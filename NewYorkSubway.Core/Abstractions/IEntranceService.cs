﻿using NewYorkSubway.Core.Models;

namespace NewYorkSubway.Core.Abstractions
{
    public interface IEntranceService
    {
        Task<GeoModelRoot> TryGetSubwayDataAsync(CancellationToken ct);
    }
}
