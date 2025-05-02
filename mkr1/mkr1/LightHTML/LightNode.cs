namespace mkr1.LightHTML
{
    public abstract class LightNode
    {
        public LightNode()
        {
            OnCreated();
        }

        protected virtual void OnCreated() { }

        public string Render()
        {
            OnClassListApplied();
            OnStylesApplied();
            var html = OuterHTML;
            OnTextRendered();
            return html;
        }

        protected virtual void OnInserted(LightNode child) {}
        protected virtual void OnRemoved(LightNode child) {}
        protected virtual void OnStylesApplied() {}
        protected virtual void OnClassListApplied() {}
        protected virtual void OnTextRendered() {}

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