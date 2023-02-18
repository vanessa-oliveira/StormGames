namespace StormGames.Application.Services;

public interface ITokenService
{
    Task<string> CreateToken(string email);
}