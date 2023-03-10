namespace StormGames.Domain.Entities;

public class Game : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
    public double Price { get; set; }
    public IList<Genre>? Genres { get; set; }
}