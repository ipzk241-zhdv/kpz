interface IMediator
{
    void OnAircraftLandingRequest(Aircraft aircraft);
    void OnAircraftTakeOffRequest(Aircraft aircraft);
}