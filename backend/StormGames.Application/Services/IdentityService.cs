using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using StormGames.Domain.Entities;

namespace StormGames.Application.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<bool> SigninUserAsync(string userName, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
        return result.Succeeded;
    }
}