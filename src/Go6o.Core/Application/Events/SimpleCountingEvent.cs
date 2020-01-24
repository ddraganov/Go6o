using MediatR;

namespace Go6o.Core.Application.Events
{
    public class SimpleCountingEvent : INotification
    {
        public SimpleCountingEvent(string message)
        {
            Message = message;
        }

        public string Message { get;  }
    }
}
