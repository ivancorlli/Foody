using Backend.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Context;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Name).HasColumnType("varchar").HasMaxLength(150);

        builder.HasMany(x=>x.Recipes).WithOne().HasForeignKey(x=>x.CategoryId);
    }
}