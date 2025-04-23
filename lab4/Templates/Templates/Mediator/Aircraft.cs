using System;

class Aircraft : BaseComponent
{
    public bool IsTakingOff { get; set; } = false;

    public Aircraft(string name) : base(name) { }

    public void RequestLanding()
    {
        Console.WriteLine($"\nAircraft {Name} is requesting to land.");
        _mediator?.OnAircraftLandingRequest(this);
    }

    public void RequestTakeOff()
    {
        Console.WriteLine($"\nAircraft {Name} is requesting to take off.");
        _mediator?.OnAircraftTakeOffRequest(this);
    }
}