namespace Backend.Interface;

public interface ICategoryRepository
{
  public ValueTask<bool> IsNameUsed(string Name);
}
