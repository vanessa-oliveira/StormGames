using StormGames.Application.Models;


namespace StormGames.Application.Queries;

public interface IGenreQueries
{
    public Task<GenreModel> GetGenreById(Guid id);
    public Task<IList<GenreModel>> GetAllGenres();
}