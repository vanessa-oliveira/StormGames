using StormGames.Application.Models;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Queries;

public class GenreQueries : IGenreQueries
{
    private readonly IGenreRepository _genreRepository;

    public GenreQueries(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<GenreModel> GetGenreById(Guid id)
    {
        var genre = await _genreRepository.GetGenreById(id);
        var genreOutput = new GenreModel
        {
            Id = genre.Id,
            Name = genre.Name
        };
        return genreOutput;
    }

    public async Task<IList<GenreModel>> GetAllGenres()
    {
        var genres = await _genreRepository.GetAllGenres();
        return genres.Select(genre => new GenreModel {Id = genre.Id, Name = genre.Name}).ToList();
    }
}