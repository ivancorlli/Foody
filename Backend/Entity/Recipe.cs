using Backend.ValueObject;

namespace Backend.Entity;

public sealed class Recipe
{
    public Guid Id {get; private set;}
    public Title Title {get;private set;}
    public Guid CategoryId {get;private set;}
    public Description? Description {get;private set;}
    public DateTimeOffset CreatedAt {get; private set;}
    public DateTimeOffset ModifiedAt {get;private set;}   

    public Recipe(Title title, Guid Category)
    {
        Id = Guid.NewGuid();
        CategoryId = Category;
        Title = title;
    }
}