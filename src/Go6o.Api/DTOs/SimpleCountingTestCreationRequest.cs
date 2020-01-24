namespace Go6o.Api.DTOs
{
    public class SimpleCountingTestCreationRequest : TestCreationRequestBase
    {    
        public int CountStep { get; set; }
        public double AToBRatioStep { get; set; }
    }
}
