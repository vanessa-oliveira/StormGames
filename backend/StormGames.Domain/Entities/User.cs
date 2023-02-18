
using Microsoft.AspNetCore.Identity;

namespace StormGames.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Active { get; set; }
    public Role Role { get; set; }

}