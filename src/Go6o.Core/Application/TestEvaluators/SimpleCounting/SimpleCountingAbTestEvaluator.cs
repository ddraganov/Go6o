using Go6o.Core.Application.Events.SimpleCounting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Go6o.Core.Application.TestEvaluators.SimpleCounting
{
    public class SimpleCountingAbTestEvaluator : AbTestEvaluatorBase
    {
        private readonly int _step;
        private readonly double _aToBRatioStep;
        private int _count;

        public SimpleCountingAbTestEvaluator(
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
            double aWeight = Math.Min(1.0d, AStartWeight + (_count / _step) * _aToBRatioStep);

            return GetValue(aWeight);
        }

        public override Task Evaluate(object @event, CancellationToken cancellationToken)
        {
            var simpleCountEvent = @event as SimpleCountingEvent;
            if (simpleCountEvent == null)
            {
                throw new ArgumentException("Invalid type passed.");
            }

            if (simpleCountEvent.TestId == TestId)
                _count++;
            else
                throw new ArgumentException($"Event handler for type {TestId} received an event of type {simpleCountEvent.TestId}");

            return Task.CompletedTask;
        }
    }
}
