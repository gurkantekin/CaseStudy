using Newtonsoft.Json;

namespace CaseStudy.Model.Models
{
    public class OcrResponseModel
    {

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("boundingPoly")]
        public BoundingPolyModel BoundingPoly { get; set; }
    }
}
