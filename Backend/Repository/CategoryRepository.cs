using Backend.Context;
using Backend.Entity;
using Backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public sealed class CategoryRepository : IRepository<Category>, ICategoryRepository
{
    private readonly FoodyContext _context;
    public CategoryRepository(FoodyContext context)
    {
        _context = context;
    }

    public async Task Create(Category Entity)
    {
            await _context.Categories.AddAsync(Entity);
            await _context.SaveChangesAsync();
    }

    public async IAsyncEnumerable<Category> GetAll()
    {
        var categories = await _context.Categories.ToListAsync();
        foreach (var category in categories)
        {
            yield return category;
        }

    }

    public async ValueTask<Category?> GetById(Guid Id)
    {
        Category? category = await _context.Categories.FindAsync(Id);
        return category;
    }

    public async ValueTask<bool> IsNameUsed(string Name)
    {
        var exists = await _context.Categories.Where(x => x.Name.ToLower() == Name.ToLower()).ToListAsync();
        if (exists.Count > 0) return true;
        return false;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

}