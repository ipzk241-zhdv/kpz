namespace Templates
{
    class CacheObserver : IEventListener, IInfoDisplayer
    {
        private List<int> _states = new List<int>();
        private string _statesInfo => String.Join(", ", _states);

        public void Update(int arg)
        {
            _states.Add(arg);
            Console.WriteLine($"cache update: {_statesInfo}");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"The states are: {_statesInfo}");
        }
    }
}