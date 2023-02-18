namespace StormGames.Application.Models;

public class UserResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Active { get; set; }
}