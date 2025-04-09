using System.Collections.Generic;
using Templates.Composite;

namespace Templates.Flyweight
{
    public class LightElementFlyweightFactory
    {
        private readonly Dictionary<string, LightElementNode> flyweights = new Dictionary<string, LightElementNode>();

        public LightElementNode GetElement(string tagName)
        {
            if (!flyweights.TryGetValue(tagName, out var element))
            {
                element = new LightElementNode(tagName);
                flyweights[tagName] = element;
            }
            return element;
        }

        public int Count => flyweights.Count;
    }
}
