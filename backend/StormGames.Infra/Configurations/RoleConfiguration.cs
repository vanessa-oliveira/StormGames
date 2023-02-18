using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StormGames.Domain.Entities;

namespace StormGames.Infra.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasMany(r => r.Users).WithOne(u => u.Role).OnDelete(DeleteBehavior.NoAction);
    }
}