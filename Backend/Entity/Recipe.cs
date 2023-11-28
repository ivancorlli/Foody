using Backend.ValueObject;
namespace Backend.Entity;

public sealed class Recipe
{
    public Guid Id {get; private set;}
    public Title Title {get;private set;}
    public Guid CategoryId {get;private set;}
    private IList<Step> _steps = new List<Step>();
    public IEnumerable<Step>? Steps => _steps;
    private IList<Ingridient> _ingridients {get;set;} = new List<Ingridient>();
    public IEnumerable<Ingridient> Ingridients => _ingridients.AsEnumerable();
    public string Pictures {get; private set;} = default!;
    public DateTimeOffset CreatedAt {get; private set;}
    public DateTimeOffset ModifiedAt {get;private set;}   

    public Recipe(Title title, Guid Category)
    {
        Id = Guid.NewGuid();
        CategoryId = Category;
        Title = title;
        DateTimeOffset now = DateTimeOffset.Now;
        CreatedAt =now;
        ModifiedAt = now;
    }
}