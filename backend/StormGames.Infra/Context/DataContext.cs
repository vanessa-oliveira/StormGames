using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Configurations;

namespace StormGames.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
    }
}