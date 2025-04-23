using System.Collections.Generic;
using System;

class CommandCentre : IMediator
{
    private List<Runway> _runways = new List<Runway>();
    private List<Aircraft> _aircrafts = new List<Aircraft>();
    private Dictionary<Aircraft, Runway> _assignments = new Dictionary<Aircraft, Runway>();

    public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
    {
        _runways.AddRange(runways);
        _aircrafts.AddRange(aircrafts);

        foreach (var aircraft in _aircrafts)
        {
            aircraft.SetMediator(this);
        }

        foreach (var runway in _runways)
        {
            runway.SetMediator(this);
        }
    }

    public void OnAircraftLandingRequest(Aircraft aircraft)
    {
        var availableRunway = _runways.Find(r => r.IsFree);
        if (availableRunway != null)
        {
            availableRunway.IsBusyWithAircraft = aircraft;
            availableRunway.HighlightRed();
            _assignments[aircraft] = availableRunway;
            Console.WriteLine($"Aircraft {aircraft.Name} landed on runway {availableRunway.Id}");
        }
        else
        {
            Console.WriteLine($"No free runway available for aircraft {aircraft.Name}.");
        }
    }

    public void OnAircraftTakeOffRequest(Aircraft aircraft)
    {
        if (_assignments.TryGetValue(aircraft, out var runway))
        {
            runway.IsBusyWithAircraft = null;
            runway.HighlightGreen();
            _assignments.Remove(aircraft);
            Console.WriteLine($"Aircraft {aircraft.Name} took off from runway {runway.Id}");
        }
        else
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is not assigned to any runway.");
        }
    }
}