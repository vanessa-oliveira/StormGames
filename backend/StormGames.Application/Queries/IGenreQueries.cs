using StormGames.Application.Queries.Models;

namespace StormGames.Application.Queries;

public interface IGenreQueries
{
    public Task<GenreModel> GetGenreById(int id);
    public Task<IList<GenreModel>> GetAllGenres();
}