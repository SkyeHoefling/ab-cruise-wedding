using Newtonsoft.Json;

namespace ABCruiseWedding.Models.Vision
{
    [JsonObject]
    public class Metadata
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        
        [JsonProperty("height")]
        public int Height { get; set; }
        
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}