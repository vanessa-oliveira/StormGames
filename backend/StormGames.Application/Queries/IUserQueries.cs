using StormGames.Application.Models;

namespace StormGames.Application.Queries;

public interface IUserQueries
{
    public Task<IList<UserResponse>> ListAllActiveUsers();
    public Task<LoginUserResponse> GetUserByEmail(string email);
}