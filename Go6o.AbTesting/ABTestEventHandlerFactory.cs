using System;

namespace Go6o.AbTesting
{
    public static class ABTestEventHandlerFactory
    {
        public static AbTest<TEvent> CreateHandler<TEvent>(string eventType)
            where TEvent : AbTestEvent
        {
            switch (eventType)
            {
                case "SimpleCountType":
                    return null;
                default:
                    throw new ArgumentException("Not supported type.");
            }
        }
    }
}
