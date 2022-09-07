namespace NewYorkSubway.Application.DTOs
{
    public record EntranceUsedResponseDto : BaseResponse
    {
        public EntranceUsedResponseDto(bool IsSuccess, string? Message) : base(IsSuccess, Message)
        {
        }

        public int EntranceId { get; init; }
        public string? Username { get; init; }
        public Guid Id { get; init; }
        public string? EntranceName { get; init; }
    }
}
