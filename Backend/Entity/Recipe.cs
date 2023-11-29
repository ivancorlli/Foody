using Backend.ValueObject;
namespace Backend.Entity;

public sealed class Recipe
{
    public Guid Id { get; private set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Guid CategoryId { get; private set; }
    private IList<Step> _steps = new List<Step>();
    public IEnumerable<Step>? Steps => _steps;
    private IList<Ingridient> _ingridients { get; set; } = new List<Ingridient>();
    public IEnumerable<Ingridient> Ingridients => _ingridients.AsEnumerable();
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ModifiedAt { get; private set; }

    public Recipe(Title title, Description description, Guid Category)
    {
        Id = Guid.NewGuid();
        CategoryId = Category;
        Title = title;
        Description = description;
        DateTimeOffset now = DateTimeOffset.Now;
        CreatedAt = now;
        ModifiedAt = now;
    }

    public void AddIngridient(Ingridient ingridient)
    {
        _ingridients.Add(ingridient);
        Update();
    }

    public void RemoveIngridient(Ingridient ingridient)
    {
        bool exists = _ingridients.Contains(ingridient);
        if (exists)
        {
            _ingridients.Remove(ingridient);
            Update();
        }
    }

    private void Update()
    {
        ModifiedAt = DateTimeOffset.Now;
    }
}
