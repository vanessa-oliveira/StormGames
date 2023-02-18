using StormGames.Domain.Entities;

namespace StormGames.Infra.Contracts;

public interface IGameRepository : IGenericRepository<Game>
{
    public Task<Game> GetGameById(Guid id);
    public Task<IList<Game>> GetAllGames();
}