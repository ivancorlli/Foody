namespace Backend.Entity;

public sealed class Category
{
    public Guid Id {get; private set;}
    public string Name {get; private set;}
    internal Category(string name)
    {
        Id= Guid.NewGuid();
        Name = name.ToLower();
    }   
}