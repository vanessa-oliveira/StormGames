namespace StormGames.Domain.Entities;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
    public IList<Category>? Categories { get; set; }
}