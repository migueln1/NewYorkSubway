namespace NewYorkSubway.Application.DTOs
{
    public class EntranceDto
    {
        public int EntranceId { get; set; }
        public string Name { get; init; } = "No name";
        public double? Latitude { get; init; }
        public double? Longitude { get; init; }
    }
}
