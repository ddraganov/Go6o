namespace Go6o.AbTesting
{
    public class SuccessFailAbTest : AbTest<SuccessFailAbTestEvent>
    {
        private readonly int _hitsCountRequiredForRecalculation;
        private int _successfulA;
        private int _successfulB;
        private int _failedA;
        private int _failedB;

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
            if (_successfulA + _successfulB + _failedA + _failedB < _hitsCountRequiredForRecalculation)
            {
                return GetValue(AStartWeight);
            }
            else
            {
                int totalA = _successfulA + _failedA;
                int totalB = _successfulB + _failedB;
                int total = totalA + totalB;

                // If one of the cases already has too small part of the total tests stop returning
                if ((double)totalA / total < 0.01)
                    return GetValue(0);
                if ((double)totalB / total < 0.01)
                    return GetValue(1);

                double aSuccessRate = (double)_successfulA / totalA;
                double bSuccessRate = (double)_successfulB / totalB;

                double aWeight = aSuccessRate / (aSuccessRate + bSuccessRate);

                return GetValue(aWeight);
            }
        }

        public override void Handle(SuccessFailAbTestEvent @event)
        {
            if (@event.Case == Case.A)
            {
                if (@event.Outcome == BinaryOutcome.Success)
                {
                    _successfulA++;
                }
                else // on BinaryOutcome.Failure
                {
                    _failedA++;
                }
            }
            else // on Case.B
            {
                if (@event.Outcome == BinaryOutcome.Success)
                {
                    _successfulB++;
                }
                else // on BinaryOutcome.Failure
                {
                    _failedB++;
                }
            }
        }
    }
}
