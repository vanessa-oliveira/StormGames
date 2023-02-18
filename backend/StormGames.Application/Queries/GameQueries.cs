using StormGames.Application.Models;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Queries;

public class GameQueries : IGameQueries
{
    private readonly IGameRepository _gameRepository;

    public GameQueries(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    
    public async Task<GameModel> GetGameById(Guid id)
    {
        var game = await _gameRepository.GetGameById(id);
        var genres = new List<GenreModel>();
        if (game.Genres != null)
        {
            genres.AddRange(game.Genres.Select(genre => new GenreModel {Name = genre.Name}));
        }
        var gameOutput = new GameModel
        {
            Title = game.Title,
            Description = game.Description,
            ReleaseDate = game.ReleaseDate,
            Developer = game.Developer,
            Publisher = game.Publisher,
            Genres = genres,
        };
        
        return gameOutput;
    }

    public async Task<IList<GameModel>> GetAllGames()
    {
        var games = await _gameRepository.GetAllGames();
        var gamesOutput = new List<GameModel>();
        
        foreach (var game in games)
        {
            if (game.Genres != null)
            {
                var genresOutput = new List<GenreModel>();
                foreach (var genre in game.Genres)
                {
                    genresOutput.Add(new GenreModel
                    {
                        Name = genre.Name
                    });
                }
                gamesOutput.Add(new GameModel
                {
                    Id = game.Id,
                    Title = game.Title,
                    Description = game.Description,
                    ReleaseDate = game.ReleaseDate,
                    Developer = game.Developer,
                    Publisher = game.Publisher,
                    Genres = genresOutput
                });
            }
            
        }

        return gamesOutput;
    }
}