using MediatR;
using StormGames.Application.Commands.Games;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Games;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Game>
{
    private readonly IGameRepository _gameRepository;
    private readonly IGenreRepository _genreRepository;

    public UpdateGameCommandHandler(IGameRepository gameRepository, IGenreRepository genreRepository)
    {
        _gameRepository = gameRepository;
        _genreRepository = genreRepository;
    }

    public async Task<Game> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        var genres = new List<Genre>();
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
            Developer = command.Developer,
            Publisher = command.Publisher,
            Genres = genres
        };
        _gameRepository.Update(game);
        return game;
    }
}