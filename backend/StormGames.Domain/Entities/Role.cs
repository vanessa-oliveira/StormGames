using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace StormGames.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public IList<User> Users { get; set; }

    public Role()
    {
        
    }

    public Role(string name)
    {
        Name = name;
    }
}