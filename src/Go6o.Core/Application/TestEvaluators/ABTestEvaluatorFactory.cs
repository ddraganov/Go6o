using Go6o.Core.Application.TestEvaluators.SuccessFail;
using System;
using System.Collections.Concurrent;

namespace Go6o.Core.Application.TestEvaluators
{
    public static class ABTestEvaluatorFactory
    {
        private static readonly ConcurrentDictionary<string, AbTestEvaluatorBase> _dict = new ConcurrentDictionary<string, AbTestEvaluatorBase>();

        static ABTestEvaluatorFactory()
        {
            _dict.TryAdd("Burgas", new SuccessFailAbTestEvaluator("Burgas", "A", "B", 0.5d, 10));
            _dict.TryAdd("NoSeaSide", new SuccessFailAbTestEvaluator("NoSeaSide", "A", "B", 0.5d, 10));
            _dict.TryAdd("Plovdiv", new SuccessFailAbTestEvaluator("Plovdiv", "A", "B", 0.5d, 10));
            _dict.TryAdd("SeaSide", new SuccessFailAbTestEvaluator("SeaSide", "A", "B", 0.5d, 10));
            _dict.TryAdd("Sofia", new SuccessFailAbTestEvaluator("Sofia", "A", "B", 0.5d, 10));
            _dict.TryAdd("Varna", new SuccessFailAbTestEvaluator("Varna", "A", "B", 0.5d, 10));
        }

        public static AbTestEvaluatorBase GetEvaluator(string testId)
        {
            if(!_dict.TryGetValue(testId, out AbTestEvaluatorBase evaluator))
            {
                throw new ArgumentException($"Evaluator not found for testId : {testId}");
            }

            return evaluator;
        }
    }
}
