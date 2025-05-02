using mkr1.LightHTML;

namespace mkr1.Iterator
{
    public class DepthFirstIterator : ILightIterator<LightNode>
    {
        private readonly LightElementNode _root;
        private readonly Stack<(LightNode Node, int ChildIndex)> _stack;
        private LightNode? _current;

        public DepthFirstIterator(LightElementNode root)
        {
            _root = root;
            _stack = new Stack<(LightNode, int)>();
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
            if (_stack.Count == 0)
                return false;

            var (node, index) = _stack.Pop();

            _current = node;

            if (node is LightElementNode elem && elem.Children.Count > 0)
            {
                for (int i = elem.Children.Count - 1; i >= 0; i--)
                {
                    var child = elem.Children[i];
                    _stack.Push((child, 0));
                }
            }

            return true;
        }

        public void Reset()
        {
            _stack.Clear();
            _stack.Push((_root, 0));
            _current = null;
        }
    }
}
