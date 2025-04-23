internal class Memento : IMemento
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Date { get; } = DateTime.Now;
    private readonly string _state;

    public Memento(string state)
    {
        _state = state;
    }

    public string GetState() => _state;
}