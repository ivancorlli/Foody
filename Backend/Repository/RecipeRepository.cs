using Backend.Context;
using Backend.Entity;
using Backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public sealed class RecipeRepository : IRepository<Recipe>
{
    private  readonly FoodyContext _context;
    public RecipeRepository(FoodyContext context)
    {
        _context = context;
    } 
    public async Task Create(Recipe Entity)
    {
      await _context.Recipes.AddAsync(Entity);
      await _context.SaveChangesAsync(); 
    }

    public async IAsyncEnumerable<Recipe> GetAll()
    {
        var recipes= await _context.Recipes.ToListAsync();
        foreach (var recipe in  recipes)
        {
            yield return recipe;
        }
    }

    public async ValueTask<Recipe?> GetById(Guid Id)
    {
        return await _context.Recipes.FindAsync(Id);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}