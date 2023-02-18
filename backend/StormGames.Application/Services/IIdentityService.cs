namespace StormGames.Application.Services;

public interface IIdentityService
{
    public Task<bool> SigninUserAsync(string userName, string password);
}