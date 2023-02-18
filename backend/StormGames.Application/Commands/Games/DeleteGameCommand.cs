using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Games;

public class DeleteGameCommand : IRequest<Game>
{
    public Guid Id { get; set; }
}