namespace mkr1.Iterator
{
    public interface ILightAggregable<T>
    {
        ILightIterator<T> GetIterator(IteratorType type);
    }

    public enum IteratorType
    {
        DepthFirst,
        BreadthFirst
    }
}
