using Backend.Entity;
using Backend.Error;
using Backend.Interface;

namespace Backend.Service;

public sealed class CategoryService
{
  private readonly ICategoryRepository _repo;
  public CategoryService(ICategoryRepository repo)
  {
    _repo = repo;
  }

  public Category Create(string name)
  {
    bool exists = _repo.IsNameUsed(name.ToLower());
    if (exists) throw new CategoryAlreadyExists(name.ToLower());
    Category newCat = new(name);
    return newCat;
  }
}
