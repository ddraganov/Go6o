using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Go6o.Core.Application.Events
{
    public class SimpleCountingEventHandler : INotificationHandler<SimpleCountingEvent>
    {
        public Task Handle(SimpleCountingEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
