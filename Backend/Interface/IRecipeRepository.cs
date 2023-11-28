using Backend.Entity;

namespace Backend.Interface;

public interface IRecipeRepository
{
  public void Create(Recipe Recipe);
}
