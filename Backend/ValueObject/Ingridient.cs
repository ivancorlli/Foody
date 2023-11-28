using Backend.Enum;

namespace Backend.ValueObject;

public sealed record Ingridient
{
    public string Name {get; private set;}
    public double Qty {get; private set;}
    public Measure Measure {get; private set;}
    public Ingridient(string name, double qty, Measure measure)
    {
        Name = name;
        Qty = qty;
        Measure = measure;
    }   
}