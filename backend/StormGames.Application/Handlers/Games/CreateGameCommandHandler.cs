using MediatR;
using StormGames.Application.Commands.Games;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Games;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
{
    private readonly IGameRepository _gameRepository;
    private readonly IGenreRepository _genreRepository;

    public CreateGameCommandHandler(IGameRepository gameRepository, IGenreRepository genreRepository)
    {
        _gameRepository = gameRepository;
        _genreRepository = genreRepository;
    }

    public async Task<Game> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        IList<Genre> genres = new List<Genre>();
        if (command.GenreIds != null)
        {
            foreach (var genreId in command.GenreIds)
            {
                var genre = await _genreRepository.GetGenreById(genreId);
                genres.Add(genre);
            }
        }
        var game = new Game
        {
            Title = command.Title,
            Description = command.Description,
            ReleaseDate = command.ReleaseDate,
            Price = command.Price,
            Developer = command.Developer,
            Publisher = command.Publisher,
            Genres = genres,
        };
        await _gameRepository.Insert(game);
        return game;
    }
}