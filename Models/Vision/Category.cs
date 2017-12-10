using System.Collections.Generic;
using Newtonsoft.Json;

namespace ABCruiseWedding.Models.Vision
{
    [JsonObject]
    public class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("score")]
        public double Score { get; set; }
        
        [JsonProperty("detail")]
        public Detail Detail { get; set; }
    }
}