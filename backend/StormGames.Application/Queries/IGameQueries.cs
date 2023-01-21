using StormGames.Application.Queries.Models;

namespace StormGames.Application.Queries;

public interface IGameQueries
{
    public Task<GameModel> GetGameById(int id);
    public Task<IList<GameModel>> GetAllGames();
}