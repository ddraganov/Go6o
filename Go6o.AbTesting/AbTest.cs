namespace Go6o.AbTesting
{
    public abstract class AbTest<TEvent> : IABTestEventHandler<TEvent>
       where TEvent : AbTestEvent
    {
        public string TestId { get; }
        protected string A { get; }
        protected string B { get; }
        protected double AStartWeight { get; }

        public AbTest(string testId, string a, string b, double aStartWeight)
        {
            TestId = testId;
            A = a;
            B = b;
            AStartWeight = AStartWeight;
        }

        public abstract void Handle(TEvent @event);

        public abstract string GetValue();
    }
}
