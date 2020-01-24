using System;
using System.Threading;
using System.Threading.Tasks;

namespace Go6o.Core.Application.TestEvaluators.SuccessFail
{
    public class SuccessFailAbTest : AbTestEvaluatorBase
    {
        private readonly int _hitsCountRequiredForRecalculation;

        public SuccessFailAbTest(
            string testId,
            string a,
            string b,
            double aStartWeight,
            int hitsCountRequiredForRecalculation)
            : base(testId, a, b, aStartWeight)
        {
            _hitsCountRequiredForRecalculation = hitsCountRequiredForRecalculation;
        }

        public override Task Evaluate(object @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public override string GetValue()
        {
            throw new NotImplementedException();
        }

        //public override void Handle(SuccessFailAbTestEvent @event)
        //{
        //    //_eventsCount++;
        //}
    }
}
