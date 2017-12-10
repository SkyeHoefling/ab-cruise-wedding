using System.Collections.Generic;
using Newtonsoft.Json;

namespace ABCruiseWedding.Models.Vision
{
    [JsonObject]
    public class Detail
    {
        [JsonProperty("landmarks")]
        public List<object> Landmarks { get; set; }
    }
}