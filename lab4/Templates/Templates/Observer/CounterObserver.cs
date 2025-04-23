namespace Templates
{
    class CounterObserver : IEventListener, IInfoDisplayer
    {
        private int _state = 0;

        public void Update(int arg)
        {
            _state++;
            Console.WriteLine($"counter update: {_state}");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"The state is: {_state}");
        }
    }
}