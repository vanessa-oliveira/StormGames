using StormGames.Domain.Entities;

namespace StormGames.Infra.Contracts;

public interface IGenreRepository : IGenericRepository<Genre>
{
    public Task<Genre> GetGenreById(int id);
    public Task<IList<Genre>> GetAllGenres();
}