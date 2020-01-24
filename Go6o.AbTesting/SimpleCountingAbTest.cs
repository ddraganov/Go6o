using System;

namespace Go6o.AbTesting
{
    public class SimpleCountingAbTest : AbTest<SimpleCountingAbTestEvent>
    {
        private readonly int _step;
        private readonly double _aToBRatioStep;
        private int _count;

        public SimpleCountingAbTest(
            string testId, 
            string a, 
            string b, 
            double aStartWeight, 
            int countStep,
            double aToBRatioStep)
            : base (testId, a, b, aStartWeight)
        {
            _step = countStep;
            _aToBRatioStep = aToBRatioStep;
        }

        public override string GetValue()
        {
            double aWeight = Math.Min(1.0d, _aStartWeight + (_count / _step) * _aToBRatioStep);

            var random = new Random();
            if (random.NextDouble() < aWeight)
                return _a;
            else
                return _b;
        }

        public override void Handle(SimpleCountingAbTestEvent @event)
        {
            if (@event.TestId == TestId)
                _count++;
            else
                throw new ArgumentException($"Event handler for type {TestId} received an event of type {@event.TestId}");
        }
    }
}
