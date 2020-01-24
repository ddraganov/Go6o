using Go6o.Core.Application.TestEvaluators.SimpleCounting;
using System;
using System.Collections.Concurrent;

namespace Go6o.Core.Application.TestEvaluators
{
    public static class ABTestEvaluatorFactory
    {
        private static readonly ConcurrentDictionary<string, AbTestEvaluatorBase> _dict = new ConcurrentDictionary<string, AbTestEvaluatorBase>();

        static ABTestEvaluatorFactory()
        {
            _dict.TryAdd("simple", new SimpleCountingAbTestEvaluator("simple", "", "", 0.5d, 5, 0.5d));
        }

        public static AbTestEvaluatorBase CreateInstance(string testId)
        {
            if(!_dict.TryGetValue(testId, out AbTestEvaluatorBase evaluator))
            {
                throw new ArgumentException($"Evaluator not found for testId : {testId}");
            }

            return evaluator;
        }
    }
}
