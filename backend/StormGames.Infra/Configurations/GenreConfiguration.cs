using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StormGames.Domain.Entities;

namespace StormGames.Infra.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        //builder.Property(c => c.Id).UseIdentityColumn(seed: 1, increment: 1);
        builder.Property(c => c.Name).HasMaxLength(50);
    }
}