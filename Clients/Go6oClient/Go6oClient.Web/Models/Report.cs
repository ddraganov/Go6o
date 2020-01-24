using System.Text.Json;

namespace Go6oClient.Web.Models
{
    public class Report
    {
        public Report()
        {

        }

        public Report(string eventId, int currentCase, int outcome)
        {
            EventId = eventId;
            Case = currentCase;
            Outcome = outcome;
        }

        public string EventId { get; set; }

        public int Case { get; set; }

        public int Outcome { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
