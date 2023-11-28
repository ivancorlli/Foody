namespace Backend.ValueObject;

public sealed record Step
{
    public string Name {get;private set;}
    public string Description {get;private set;}
    private IList<string> pictures = new List<string>();
    public IEnumerable<string> Pictures => pictures;
    public Step(string name,string description)
    {
        Name = name.ToLower();
        Description = description;
    } 
}