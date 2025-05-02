namespace mkr1.LightHTML
{
    public abstract class LightNode
    {
        public LightNode()
        {
            OnCreated();
        }

        protected virtual void OnCreated() { Console.WriteLine($"{GetType().Name} created!"); }

        public string Render()
        {
            OnClassListApplied();
            OnStylesApplied();
            var html = OuterHTML;
            OnTextRendered();
            return html;
        }

        protected virtual void OnInserted(LightNode child) { Console.WriteLine($"{GetType().Name} inserted with new child {child.GetType().Name}!"); }
        protected virtual void OnRemoved(LightNode child) { Console.WriteLine($"{GetType().Name} doesnt have {child.GetType().Name} anymore as child!"); }
        protected virtual void OnStylesApplied() { Console.WriteLine($"{GetType().Name} styles were applied!"); }
        protected virtual void OnClassListApplied() { Console.WriteLine($"{GetType().Name} class list applied!"); }
        protected virtual void OnTextRendered() { Console.WriteLine($"{GetType().Name} text rendered!"); }

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

        public override string OuterHTML
        {
            get
            {
                OnTextRendered();
                return Text;
            }
        }

        public override string InnerHTML => Text;
    }

    public enum DisplayType { Block, Inline }
    public enum ClosingType { SelfClosing, WithClosingTag }
}