using StormGames.Domain.Entities;

namespace StormGames.Application.Models;

public class GameModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
    public IList<GenreModel>? Genres { get; set; }
}