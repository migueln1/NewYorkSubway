namespace NewYorkSubway.Core.Models
{
    public class UserEntrance : Entity<Guid>
    {
        public string? UserId { get; init; }
        public int EntranceId  { get; init; }
    }
}
