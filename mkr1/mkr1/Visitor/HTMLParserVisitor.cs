using mkr1.LightHTML;

namespace mkr1.Visitor
{
    public class HTMLParserVisitor : IVisitor
    {
        private readonly HashSet<string> _classes = new HashSet<string>();
        public IReadOnlyCollection<string> Classes => _classes;

        private readonly HashSet<string> _texts = new HashSet<string>();
        public IReadOnlyCollection<string> Texts => _texts;

        public void Visit(LightTextNode textNode)
        {
            _texts.Add(textNode.InnerHTML);
        }

        public void Visit(LightElementNode elementNode)
        {
            foreach (var cls in elementNode.CssClasses)
                _classes.Add(cls);
        }
    }
}
