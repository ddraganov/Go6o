namespace Go6o.AbTesting
{
    public interface IABTestEventHandler<in TEvent>
        where TEvent : AbTestEvent
    {
        public void Handle(TEvent @event);
    }
}
