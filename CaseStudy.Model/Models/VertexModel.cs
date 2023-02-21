using Newtonsoft.Json;

namespace CaseStudy.Model.Models
{
    public class VertexModel
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
