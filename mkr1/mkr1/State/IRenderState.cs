using mkr1.LightHTML;

namespace mkr1.State
{
    public interface IRenderState
    {
        public string GetOuterHTML(LightElementNode element);
    }
}
