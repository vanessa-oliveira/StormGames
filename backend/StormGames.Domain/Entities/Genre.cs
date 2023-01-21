namespace StormGames.Domain.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Game>? Games { get; set; }

    public void UpdateGenre(string newName)
    {
        Name = newName;
    }
}