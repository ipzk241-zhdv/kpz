using System;

class Runway : BaseComponent
{
    public readonly Guid Id = Guid.NewGuid();
    public Aircraft? IsBusyWithAircraft;

    public Runway(string? name) : base(name) { }

    public bool IsFree => IsBusyWithAircraft == null;

    public void HighlightRed()
    {
        Console.WriteLine($"Runway {Id} is now busy.");
    }

    public void HighlightGreen()
    {
        Console.WriteLine($"Runway {Id} is now free.");
    }
}