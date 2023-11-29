using Backend.Entity;
using Backend.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Context;

public sealed class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.HasIndex(x=>x.CategoryId);

        builder.Property(x=>x.Title.Value).HasColumnType("varchar");
        builder.Property(x=>x.Description.Value).HasColumnType("varchar");
        builder.OwnsMany(x=>x.Steps,s=>{
            s.Property(x=>x.Name).HasColumnType("varchar");
            s.Property(x=>x.Description).HasColumnType("varchar");
            s.Property(x=>x.Picture).HasColumnType("varchar");
        });

        builder.OwnsMany(x=>x.Ingridients,i=>{
            i.Property(x=>x.Name).HasColumnType("varchar");
            i.Property(x=>x.Qty);
            i.Property(x=>x.Measure).HasConversion(x=>x.ToString(),s=>(Measure)System.Enum.Parse(typeof(Measure),s));
        });

        builder.Property(x=>x.CreatedAt);
        builder.Property(x=>x.ModifiedAt);
    }
}