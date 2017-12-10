using System.Collections.Generic;
using Newtonsoft.Json;

namespace ABCruiseWedding.Models.Vision
{
    [JsonObject]
    public class AnalyzeImage
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
        
        [JsonProperty("description")]
        public Description Description { get; set; }
        
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}