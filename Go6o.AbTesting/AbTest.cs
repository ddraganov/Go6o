using System;

namespace Go6o.AbTesting
{
    public abstract class AbTest<TEvent>
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

        protected string GetValue(double aWeight)
        {
            var random = new Random();
            if (random.NextDouble() < aWeight)
                return A;
            else
                return B;
        }
    }
}
