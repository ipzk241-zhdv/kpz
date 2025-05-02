using mkr1.LightHTML;

namespace mkr1.Iterator
{
    public class BreadthFirstIterator : ILightIterator<LightNode>
    {
        private readonly LightElementNode _root;
        private readonly Queue<LightNode> _queue;
        private LightNode? _current;

        public BreadthFirstIterator(LightElementNode root)
        {
            _root = root;
            _queue = new Queue<LightNode>();
            Reset();
        }

        public LightNode Current
        {
            get
            {
                if (_current is null)
                    throw new InvalidOperationException("Enumeration has not started. Call MoveNext().");
                return _current;
            }
        }

        public bool MoveNext()
        {
            if (_queue.Count == 0)
                return false;

            _current = _queue.Dequeue();

            if (_current is LightElementNode elem)
            {
                foreach (var child in elem.Children)
                {
                    _queue.Enqueue(child);
                }
            }

            return true;
        }

        public void Reset()
        {
            _queue.Clear();
            _queue.Enqueue(_root);
            _current = null;
        }
    }
}
