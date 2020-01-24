using System;
using System.Collections.Generic;
using System.Text;

namespace Go6o.AbTesting
{
    public class SimpleCountingAbTest : AbTest<SimpleCountingAbTestEvent>
    {
        private readonly string _a;
        private readonly string _b;
        private readonly double _aStartWeight;
        private readonly int _step;
        private readonly double _aToBRatioStep;
        private int _count;

        public SimpleCountingAbTest(
            string eventType, 
            string a, 
            string b, 
            double aStartWeight, 
            int countStep,
            double aToBRatioStep)
        {
            EventType = eventType;
            _a = a;
            _b = b;
            _aStartWeight = aStartWeight;
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
            if (@event.EventType == EventType)
                _count++;
            else
                throw new ArgumentException($"Event handler for type {EventType} received an event of type {@event.EventType}");
        }
    }
}
