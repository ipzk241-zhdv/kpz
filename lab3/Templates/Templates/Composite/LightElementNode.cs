using System.Collections.Generic;
using System.Linq;

namespace Templates.Composite
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; } = new List<string>();
        public List<LightNode> Children { get; } = new List<LightNode>();

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

        public override string OuterHTML
        {
            get
            {
                string classAttribute = CssClasses.Count > 0
                    ? $" class=\"{string.Join(" ", CssClasses)}\""
                    : "";

                if (Closing == ClosingType.SelfClosing)
                    return $"<{TagName}{classAttribute}/>";

                return $"<{TagName}{classAttribute}>{InnerHTML}</{TagName}>";
            }
        }
    }
}
