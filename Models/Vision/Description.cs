using System.Collections.Generic;
using Newtonsoft.Json;

namespace ABCruiseWedding.Models.Vision
{
    [JsonObject]
    public class Description
    {
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        
        [JsonProperty("captions")]
        public List<Caption> Captions { get; set; }
    }
}