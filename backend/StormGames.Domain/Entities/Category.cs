﻿namespace StormGames.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void UpdateCategory(string newName)
    {
        Name = newName;
    }
}