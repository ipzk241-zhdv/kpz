public class Caretaker
{
    private readonly IOriginator _originator;
    private readonly List<IMemento> _snapshots = new List<IMemento>();

    public Caretaker(IOriginator originator)
    {
        _originator = originator;
    }

    public void Backup()
    {
        _snapshots.Add(_originator.Save());
    }

    public void Undo()
    {
        if (!_snapshots.Any())
        {
            Console.WriteLine("No snapshots to restore.");
            return;
        }

        var snapshot = _snapshots.Last();
        Console.WriteLine($"Undoing to snapshot {snapshot.Id} from {snapshot.Date}");
        _originator.Restore(snapshot);
        _snapshots.Remove(snapshot);
    }

    public void RenderSnapshotList()
    {
        Console.WriteLine("Currently available snapshots:");
        foreach (var snap in _snapshots)
        {
            Console.WriteLine($"- {snap.Id} taken at {snap.Date}");
        }
    }
}