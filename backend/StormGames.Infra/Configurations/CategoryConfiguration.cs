using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StormGames.Domain.Entities;

namespace StormGames.Infra.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Id).UseIdentityColumn(seed: 1, increment: 1);
        builder.Property(c => c.Name).HasMaxLength(50);
    }
}