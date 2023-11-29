namespace Backend.ValueObject;

public sealed record Step
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string? Picture { get; private set; }
    public Step(string name, string description, string? picture)
    {
        Name = name.ToLower();
        Description = description;
        Picture = picture;
    }
}
