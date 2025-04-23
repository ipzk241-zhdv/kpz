using System.Collections.Generic;
using System.Linq;

namespace Templates.Composite
{
    public class LightImageNode : LightNode
    {
        public string Href { get; }
        private readonly ImageLoaderContext _loaderContext;

        public LightImageNode(string href)
        {
            Href = href;
            var strategy = href.StartsWith("http://") || href.StartsWith("https://")
                ? (IImageLoaderStrategy)new NetworkImageLoaderStrategy()
                : new FileImageLoaderStrategy();

            _loaderContext = new ImageLoaderContext(strategy);
        }

        public void LoadImage()
        {
            _loaderContext.Load(Href);
        }

        public override string InnerHTML => string.Empty;

        public override string OuterHTML => $"<img src=\"{Href}\"/>";
    }
}
