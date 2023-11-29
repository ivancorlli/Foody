namespace Backend.Entity;

public sealed class Category
{
  public Guid Id { get; private set; }
  public string Name { get; private set; } = default!;
  private readonly ICollection<Recipe> _recipes = new List<Recipe>();
  public ICollection<Recipe> Recipes => _recipes;

  private Category(){}

  internal Category(string name)
  {
    Id = Guid.NewGuid();
    Name = name.ToLower();
  }

  public void ChangeName(string name)
  {
    Name = name.ToLower();
  }
}
