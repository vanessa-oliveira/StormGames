namespace StormGames.Application.Models;

public class LoginUserResponse
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }

    public LoginUserResponse()
    {
        
    }
}