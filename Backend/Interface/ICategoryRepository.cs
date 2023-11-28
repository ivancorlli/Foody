namespace Backend.Interface;

public interface ICategoryRepository
{
  public bool IsNameUsed(string Name);
}
