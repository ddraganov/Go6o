namespace Go6o.AbTesting
{
    public class SuccessFailAbTestEvent : AbTestEvent
    {
        public Case Case { get; set; }

        public BinaryOutcome Outcome { get; set; }
    }
}