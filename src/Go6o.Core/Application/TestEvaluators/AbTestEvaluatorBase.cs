using System.Threading;
using System.Threading.Tasks;

namespace Go6o.Core.Application.TestEvaluators
{
    public abstract class AbTestEvaluatorBase
    {
        public string TestId { get; }
        protected string A { get; }
        protected string B { get; }
        protected double AStartWeight { get; }

        public AbTestEvaluatorBase(string testId, string a, string b, double aStartWeight)
        {
            TestId = testId;
            A = a;
            B = b;
            AStartWeight = AStartWeight;
        }

        public abstract string GetValue();

        public abstract Task Evaluate(object @event, CancellationToken cancellationToken);
    }
}
