namespace NewYorkSubway.Core.Models;

public class UserSignUpModel
{
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
public class UserSignUpResponseModel
{
    public string UserId { get; set; }
    public string EmailAddress { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
}

