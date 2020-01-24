using Go6o.Core.Application.TestEvaluators;
using MediatR;

namespace Go6o.Core.Application.Events.SuccessFail
{
    public class SuccessFailEvent : EventBase, INotification
    {
        public Case Case { get; set; }
        public BinaryOutcome Outcome { get; set; }
    }
}
