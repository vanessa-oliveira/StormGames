using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Games;

public class UpdateGameCommand : IRequest<Game>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
    public IList<int>? CategoryIds { get; set; }
}