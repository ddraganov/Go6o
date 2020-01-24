using System;
using System.Collections.Generic;
using System.Text;

namespace Go6o.AbTesting
{
    public interface IAbTest<TEvent>
    {
        public string EventType { get; }

        void Handle(TEvent @event);

        string GetValue();
    }
}
