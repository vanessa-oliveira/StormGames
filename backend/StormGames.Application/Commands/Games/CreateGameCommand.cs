using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Games;

public class CreateGameCommand : IRequest<Game>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double Price { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
    public IList<Guid>? GenreIds { get; set; }
}