using MediatR;
using StormGames.Application.Commands.Games;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Games;

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Game>
{
    private readonly IGameRepository _gameRepository;

    public DeleteGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> Handle(DeleteGameCommand command, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameById(command.Id);
        _gameRepository.Delete(game);
        return game;
    }
}