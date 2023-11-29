using Backend.Context;
using Backend.Entity;
using Backend.Interface;

namespace Backend.Repository;

public sealed class CategoryRepository:IRepository<Category>,ICategoryRepository
{
    private readonly FoodyContext _context;
    public CategoryRepository(FoodyContext context)
    {
        _context = context;
    }

    public void Create(Category Entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAll()
    {
        throw new NotImplementedException();
    }

    public Category GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public bool IsNameUsed(string Name)
    {
        throw new NotImplementedException();
    }

    public void Save(Category Entity)
    {
        throw new NotImplementedException();
    }
}