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

        public void SetRenderState(IRenderState state) => _renderState = state;

        public override string OuterHTML => _renderState.GetOuterHTML(this);

        public string GenerateFullHTML()
        {
            string classAttribute = CssClasses.Count > 0
                ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";

            if (Closing == ClosingType.SelfClosing)
                return $"<{TagName}{classAttribute}/>";

            return $"<{TagName}{classAttribute}>{InnerHTML}</{TagName}>";
        }

        public LightElementNode(string tagName, DisplayType display = DisplayType.Block, ClosingType closing = ClosingType.WithClosingTag)
        {
            TagName = tagName;
            Display = display;
            Closing = closing;
        }

        public void AddClass(string className) => CssClasses.Add(className);

        public void AddChild(LightNode child) => Children.Add(child);

        public override string InnerHTML =>
            Closing == ClosingType.SelfClosing
                ? string.Empty
                : string.Join("", Children.Select(child => child.OuterHTML));

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
