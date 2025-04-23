namespace Templates
{
    class Subject
    {
        private List<IEventListener> _subscribers = new List<IEventListener>();
        public void Subscribe(IEventListener subscriber) => _subscribers.Add(subscriber);
        public void Unsubscribe(IEventListener subscriber) => _subscribers.Remove(subscriber);
        private void _notify(int arg) => _subscribers.ForEach(s => s.Update(arg));
        public void InvokeEvent(int arg) => _notify(arg);
    }
}