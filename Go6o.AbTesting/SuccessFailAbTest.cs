using System;

namespace Go6o.AbTesting
{
    public class SuccessFailAbTest : AbTest<SuccessFailAbTestEvent>
    {
        private readonly string _a;
        private readonly string _b;
        private readonly double _aStartWeight;
        private readonly int _hitsCountRequiredForRecalculation;

        public SuccessFailAbTest(
            string eventType,
            string a,
            string b,
            double aStartWeight,
            int hitsCountRequiredForRecalculation)
        {
            EventType = eventType;
            _a = a;
            _b = b;
            _aStartWeight = aStartWeight;
            _hitsCountRequiredForRecalculation = hitsCountRequiredForRecalculation;
        }

        public override string GetValue()
        {
            throw new NotImplementedException();
        }

        public override void Handle(SuccessFailAbTestEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
