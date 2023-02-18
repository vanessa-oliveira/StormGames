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
        var game = await _gameRepository.GetGameById(command.Id);
        var genres = new List<Genre>();
        if (command.GenreIds != null)
        {
            foreach (var genreId in command.GenreIds)
            {
                var genreUpdate = await _genreRepository.GetGenreById(genreId);
                genres.Add(genreUpdate);
            }
        }
        game.Title = command.Title;
        game.Description = command.Description;
        game.ReleaseDate = command.ReleaseDate;
        game.Price = command.Price;
        game.Developer = command.Developer;
        game.Publisher = command.Publisher;
        game.Genres = genres;
        await _gameRepository.Update(game);
        return game;
    }
}