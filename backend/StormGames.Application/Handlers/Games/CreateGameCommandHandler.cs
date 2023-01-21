using MediatR;
using StormGames.Application.Commands.Games;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Games;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
{
    private readonly IGameRepository _gameRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateGameCommandHandler(IGameRepository gameRepository, ICategoryRepository categoryRepository)
    {
        _gameRepository = gameRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Game> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        IList<Category> categories = new List<Category>();
        if (command.CategoryIds != null)
        {
            foreach (var categoryId in command.CategoryIds)
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);
                categories.Add(category);
            }
        }
        var game = new Game
        {
            Title = command.Title,
            Description = command.Description,
            ReleaseDate = command.ReleaseDate,
            Developer = command.Developer,
            Publisher = command.Publisher,
            Categories = categories,
        };
        await _gameRepository.Insert(game);
        return game;
    }
}