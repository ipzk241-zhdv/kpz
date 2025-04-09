namespace Templates.Composite
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }
    }

    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHTML => Text;

        public override string InnerHTML => Text;
    }

    public enum DisplayType { Block, Inline }
    public enum ClosingType { SelfClosing, WithClosingTag }
}
