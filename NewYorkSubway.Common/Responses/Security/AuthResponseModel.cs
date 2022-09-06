namespace NewYorkSubway.Common.Models
{
    public class TokenModel
    {
        public string? AccessToken { get; init; }
        public int ExpiresIn { get; init; }
        public string? RefreshToken { get; init; }
    }
    public class AuthResponseModel
    {
        public string? UserId { get; set; }
        public TokenModel? Tokens { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
