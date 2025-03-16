namespace SingletonClassLibrary
{
    public sealed class Authenticator
    {
        private Authenticator()
        {
            Console.WriteLine("Authenticator instance created.");
        }

        // Статичне поле з Lazy<T> для потокобезпеки
        private static readonly Lazy<Authenticator> _instance =
            new Lazy<Authenticator>(() => new Authenticator());

        // Публічний доступ до єдиного екземпляра
        public static Authenticator Instance => _instance.Value;

        public void Authenticate(string user)
        {
            Console.WriteLine($"Authenticating {user}...");
        }
    }
}
