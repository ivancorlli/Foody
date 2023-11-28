namespace Backend.ValueObject;

public sealed record Description
{
    public string Value {get;private set;}
    public Description(string value)
    {
        Value = value;
    }
}