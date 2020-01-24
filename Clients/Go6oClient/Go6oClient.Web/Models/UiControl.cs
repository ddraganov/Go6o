using System.Text.Json;

namespace Go6oClient.Web.Models
{
    public class UiControl
    {
        public string NoSeaSide { get; set; }

        public string SeaSide { get; set; }

        public string Sofia { get; set; }

        public string Plovdiv { get; set; }

        public string Varna { get; set; }

        public string Burgas { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
