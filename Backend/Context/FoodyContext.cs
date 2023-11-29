using Backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context;

public class FoodyContext:DbContext
{
    public FoodyContext(DbContextOptions<FoodyContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Recipe> Recipes => Set<Recipe>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RecipeConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
    }
}
