using System.Text.Json;

namespace Go6oClient.Web.Models
{
    public class Report
    {
        public string EventId { get; set; }

        public int Case { get; set; }

        public int Outcome { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
