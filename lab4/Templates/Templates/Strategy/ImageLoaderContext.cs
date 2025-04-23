namespace Templates
{
    class ImageLoaderContext
    {
        private IImageLoaderStrategy _strategy;

        public ImageLoaderContext(IImageLoaderStrategy initialStrategy)
        {
            _strategy = initialStrategy;
        }

        public void SetStrategy(IImageLoaderStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Load(string href)
        {
            _strategy.Load(href);
        }
    }
}