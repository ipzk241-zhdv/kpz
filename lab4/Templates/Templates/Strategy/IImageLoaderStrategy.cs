namespace Templates
{
    interface IImageLoaderStrategy
    {
        void Load(string href);
    }

    class FileImageLoaderStrategy : IImageLoaderStrategy
    {
        public void Load(string href)
        {
            Console.WriteLine($"[File] Завантажую зображення з файлової системи: {href}");
        }
    }

    class NetworkImageLoaderStrategy : IImageLoaderStrategy
    {
        public void Load(string href)
        {
            Console.WriteLine($"[Network] Завантажую зображення з мережі: {href}");
        }
    }
}