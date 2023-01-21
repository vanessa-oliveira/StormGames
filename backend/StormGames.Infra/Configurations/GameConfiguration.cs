using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StormGames.Domain.Entities;

namespace StormGames.Infra.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(g => g.Id).UseIdentityColumn(seed: 1, increment: 1);
        builder.Property(g => g.Title).HasMaxLength(250);
        builder.Property(g => g.Developer).HasMaxLength(200);
        builder.Property(g => g.Publisher).HasMaxLength(200);
    }
}