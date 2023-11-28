namespace Backend.Error;

public sealed class CategoryAlreadyExists : Exception
{
  public CategoryAlreadyExists(string name) : base($" Category {name} already exists.")
  {
  }
}
