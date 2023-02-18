namespace StormGames.Domain.Entities;

public class Genre : Entity
{
    public string Name { get; set; }
    public IList<Game>? Games { get; set; }

    public void UpdateGenre(string newName)
    {
        Name = newName;
    }
}