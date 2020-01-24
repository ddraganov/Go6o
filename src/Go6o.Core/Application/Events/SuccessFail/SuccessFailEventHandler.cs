using Go6o.Core.Application.TestEvaluators;
using Go6o.Core.Application.TestEvaluators.SuccessFail;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Go6o.Core.Application.Events.SuccessFail
{
    public class SuccessFailEventHandler : INotificationHandler<SuccessFailEvent>
    {
        public Task Handle(SuccessFailEvent notification, CancellationToken cancellationToken)
        {
            var evaluator = ABTestEvaluatorFactory.GetEvaluator(notification.TestId);

            if (evaluator == null)
            {
                throw new ArgumentNullException($"Could not create an instance of {nameof(evaluator)} evaluator.");
            }

            evaluator.Evaluate(notification, CancellationToken.None);

            return Task.CompletedTask;
        }
    }
}
