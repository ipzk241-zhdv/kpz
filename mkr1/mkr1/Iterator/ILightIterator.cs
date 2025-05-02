namespace mkr1.Iterator
{
    public interface ILightIterator<T>
    {
        bool MoveNext();
        T Current { get; }
        void Reset();
    }
}
