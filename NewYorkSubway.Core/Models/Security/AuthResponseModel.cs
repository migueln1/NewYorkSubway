namespace NewYorkSubway.Core.Models
{
    public class TokenModel
    {
        public string IdToken { get; init; }
        public string AccessToken { get; init; }
        public string ExpiresIn { get; init; }
        public string RefreshToken { get; init; }
    }
    public class AuthResponseModel
    {
        public string EmailAddress { get; set; }
        public string UserId { get; set; }
        public TokenModel Tokens { get; set; }
    }
}
