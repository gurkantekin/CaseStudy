using System.Collections.Generic;
using Newtonsoft.Json;

namespace CaseStudy.Model.Models
{
    public class BoundingPolyModel
    {
        [JsonProperty("vertices")]
        public List<VertexModel> Vertices { get; set; }
    }
}
