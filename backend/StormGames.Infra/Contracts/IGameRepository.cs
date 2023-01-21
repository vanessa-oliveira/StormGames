using StormGames.Domain.Entities;

namespace StormGames.Infra.Contracts;

public interface IGameRepository : IGenericRepository<Game>
{
    public Task<Game> GetGameById(int id);
    public Task<IList<Game>> GetAllGames();
}