using StormGames.Application.Models;

namespace StormGames.Application.Queries;

public interface IGameQueries
{
    public Task<GameModel> GetGameById(Guid id);
    public Task<IList<GameModel>> GetAllGames();
}