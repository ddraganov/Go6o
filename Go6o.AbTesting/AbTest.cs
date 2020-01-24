namespace Go6o.AbTesting
{
    public abstract class AbTest<TEvent> : IABTestEventHandler<TEvent>
       where TEvent : AbTestEvent
    {
        public string EventType { get; set; }

        public abstract void Handle(TEvent @event);

        public abstract string GetValue();
    }
}
