using System;

namespace Go6o.AbTesting
{
    public class SuccessFailAbTest : AbTest<SuccessFailAbTestEvent>
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

        public override string GetValue()
        {
            throw new NotImplementedException();
        }

        public override void Handle(SuccessFailAbTestEvent @event)
        {
            //_eventsCount++;
        }
    }
}
