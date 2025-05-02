using mkr1.Iterator;
using mkr1.State;
using System.Collections.Generic;
using System.Linq;

namespace mkr1.LightHTML
{
    public class LightElementNode : LightNode, ILightAggregable<LightNode>
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; } = new List<string>();
        public List<LightNode> Children { get; } = new List<LightNode>();

        private IRenderState _renderState = new VisibleState();

        public LightElementNode(string tagName, DisplayType display = DisplayType.Block, ClosingType closing = ClosingType.WithClosingTag)
            : base()
        {
            TagName = tagName;
            Display = display;
            Closing = closing;
        }

        public void SetRenderState(IRenderState state) => _renderState = state;

        public override string OuterHTML => _renderState.GetOuterHTML(this);

        public string GenerateFullHTML()
        {
            var classAttr = CssClasses.Count > 0
                ? $" class=\"{string.Join(" ", CssClasses)}\"" : string.Empty;

            if (Closing == ClosingType.SelfClosing)
                return $"<{TagName}{classAttr}/>?";

            return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
        }

        public void AddClass(string className)
        {
            CssClasses.Add(className);
            OnClassListApplied();
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
            OnInserted(child);
        }

        public bool RemoveChild(LightNode child)
        {
            var removed = Children.Remove(child);
            if (removed) OnRemoved(child);
            return removed;
        }

        public void ApplyStyle(string styleDeclaration)
        {
            OnStylesApplied();
        }

        public override string InnerHTML =>
            Closing == ClosingType.SelfClosing
                ? string.Empty
                : string.Join("", Children.Select(child => child.Render()));

        public ILightIterator<LightNode> GetIterator(IteratorType type)
        {
            return type switch
            {
                IteratorType.DepthFirst => new DepthFirstIterator(this),
                IteratorType.BreadthFirst => new BreadthFirstIterator(this),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
