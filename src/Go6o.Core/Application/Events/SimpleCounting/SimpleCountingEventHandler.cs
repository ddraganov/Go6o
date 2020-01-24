using Go6o.Core.Application.TestEvaluators;
using Go6o.Core.Application.TestEvaluators.SimpleCounting;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Go6o.Core.Application.Events.SimpleCounting
{
    public class SimpleCountingEventHandler : INotificationHandler<SimpleCountingEvent>
    {
        public Task Handle(SimpleCountingEvent notification, CancellationToken cancellationToken)
        {
            var evaluator = ABTestEvaluatorFactory.GetEvaluator("simple");

            if(evaluator == null)
            {
                throw new ArgumentNullException($"Could not create an instance of {nameof(evaluator)} evaluator.");
            }

            evaluator.Evaluate(notification, CancellationToken.None);

            return Task.CompletedTask;
        }
    }
}
