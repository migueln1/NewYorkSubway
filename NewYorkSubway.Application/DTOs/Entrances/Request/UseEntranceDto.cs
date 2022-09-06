namespace NewYorkSubway.Application.DTOs
{
    public record UseEntranceDto
    {
        public int EntranceId { get; set; }
        public string? Username { get; set; }
    }
}
