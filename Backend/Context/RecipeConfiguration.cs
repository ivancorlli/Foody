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

        builder.OwnsOne(x=>x.Title,t=>{
            t.Property(x=>x.Value).HasColumnType("varchar").HasMaxLength(250);
        });
        builder.OwnsOne(x=>x.Description,d=>{
            d.Property(x=>x.Value).HasColumnType("varchar").HasMaxLength(750);
        });

        builder.OwnsMany(x=>x.Steps,s=>{
            s.Property(x=>x.Name).HasColumnType("varchar").HasMaxLength(250);
            s.Property(x=>x.Description).HasColumnType("varchar").HasMaxLength(750);
            s.Property(x=>x.Picture).HasColumnType("varchar").HasMaxLength(500);
        });

        builder.OwnsMany(x=>x.Ingridients,i=>{
            i.Property(x=>x.Name).HasColumnType("varchar").HasMaxLength(250);
            i.Property(x=>x.Qty);
            i.Property(x=>x.Measure).HasConversion(x=>x.ToString(),s=>(Measure)System.Enum.Parse(typeof(Measure),s));
        });

        builder.Property(x=>x.CreatedAt);
        builder.Property(x=>x.ModifiedAt);
    }
}