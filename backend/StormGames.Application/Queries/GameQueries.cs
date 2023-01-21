using StormGames.Application.Queries.Models;
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
    
    public async Task<GameModel> GetGameById(int id)
    {
        var game = await _gameRepository.GetGameById(id);
        var gameOutput = new GameModel
        {
            Title = game.Title,
            Description = game.Description,
            ReleaseDate = game.ReleaseDate,
            Developer = game.Developer,
            Publisher = game.Publisher,
        };
        if (game.Categories != null)
        {
            foreach (var category in game.Categories)
            {
                gameOutput.Categories.Add(new CategoryModel
                {
                    Name = category.Name
                });
            }
        }
        return gameOutput;
    }

    public async Task<IList<GameModel>> GetAllGames()
    {
        var games = await _gameRepository.GetAllGames();
        var gamesOutput = new List<GameModel>();
        var categoriesOutput = new List<CategoryModel>();
        
        foreach (var game in games)
        {
            if (game.Categories != null)
            {
                foreach (var category in game.Categories)
                {
                    categoriesOutput.Add(new CategoryModel
                    {
                        Name = category.Name
                    });
                }
            }
            gamesOutput.Add(new GameModel
            {
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate,
                Developer = game.Developer,
                Publisher = game.Publisher,
                Categories = categoriesOutput
            });
        }

        return gamesOutput;
    }
}