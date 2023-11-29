using Backend.Context;
using Backend.Entity;
using Backend.Interface;

namespace Backend.Repository;

public sealed class RecipeRepository : IRepository<Recipe>
{
    private  readonly FoodyContext _context;
    public RecipeRepository(FoodyContext context)
    {
        _context = context;
    } 
    public void Create(Recipe Entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Recipe> GetAll()
    {
        throw new NotImplementedException();
    }

    public Recipe GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void Save(Recipe Entity)
    {
        throw new NotImplementedException();
    }
}