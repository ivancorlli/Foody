namespace Backend.ValueObject;

public sealed record Title
{
    public string Value {get; private set;}
    public Title(string value)
    {
        Value = value.ToLower();
    }   
}