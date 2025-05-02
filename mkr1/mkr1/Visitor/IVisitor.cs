using mkr1.LightHTML;

namespace mkr1.Visitor
{
    public interface IVisitor
    {
        void Visit(LightTextNode textNode);
        void Visit(LightElementNode elementNode);
    }
}
